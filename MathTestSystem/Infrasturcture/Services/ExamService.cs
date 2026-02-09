namespace MathTestSystem.Infrasturcture.Services
{
    using MathTestSystem.Application.Interfaces;
    using MathTestSystem.Domain.Entites;
    using MathTestSystem.DTOs;
    using MathTestSystem.Infrasturcture.Data;
    using MathTestSystem.MathProcessor;
    using Microsoft.EntityFrameworkCore;
    using System.Xml.Serialization;

    public class ExamService : IExamService
    {
        private readonly IMathService mathService;
        private readonly AppDBContext context;
        public ExamService(IMathService mathService, AppDBContext context)
        {
            this.mathService = mathService;
            this.context = context;
        }

        public async Task<Dictionary<int, ExamResult>> ReadXMLContent(string xmlContent)
        {
            var examResultByStudent = new Dictionary<int, ExamResult>();
            XmlSerializer serializer = new XmlSerializer(typeof(Teacher));
            StringReader reader = new StringReader(xmlContent.Trim());
            Teacher teacher = (Teacher)serializer.Deserialize(reader);

            foreach(var student in teacher.Students)
            {                
                var examResult = await ProcessExam(student.Exam, student.Id, teacher.Id);
                this.context.ExamResults.Add(examResult);
                examResultByStudent.Add(student.Id, examResult);
            }
            await context.SaveChangesAsync();
            return examResultByStudent;
        }
        public async Task<ExamResult> ProcessExam(Exam exam, int studentId, int teacherId)
        {
            var examResult = new ExamResult
            {
                StudentId = studentId,
                TeacherId = teacherId,
                ExamId = exam.Id,
                TotalTasks = exam.MathTasks.Count
            };

            foreach (var task in exam.MathTasks)
            {
                var mathOperation = task.Formula.Split("=");
                task.StudentAnwer = Convert.ToDouble(mathOperation[1].Trim());
                task.CorrectAnswer = this.mathService.Evaluate(mathOperation[0].Trim());
                task.IsCorrect = this.mathService.CheckAnswer(task.CorrectAnswer, task.StudentAnwer);

                var taskResult = new ExamTaskResult
                {
                    TaskId = task.Id,
                    IsCorrect = task.IsCorrect,
                    CorrectAnswer = task.CorrectAnswer.ToString(),
                    StudentAnswer = task.StudentAnwer.ToString(),
                    Formula = task.Formula,
                    ExamResult = examResult
                };
                examResult.ExamTasks.Add(taskResult);
            }

            examResult.CorrectTasks = exam.MathTasks.Count(t => t.IsCorrect);
            examResult.Score = exam.MathTasks.Count(t => t.IsCorrect) * 100.0 / exam.MathTasks.Count;
            return examResult;
        }

        public async Task<List<ExamResultDTO>> GetExamResultByStudent(int studentId)
        {
            var examResults = await this.context.ExamResults
                .Include(x => x.ExamTasks)
                .Where(x => x.StudentId == studentId).ToListAsync();

            return examResults.Select(x => new ExamResultDTO
            {
                StudentId = x.StudentId,
                TeacherId = x.TeacherId,
                ExamId = x.ExamId,
                Score = x.Score,
                TotalTasks = x.TotalTasks,
                CorrectTasks = x.CorrectTasks,
                ExamTasks = x.ExamTasks.Select(t => new ExamTaskResultDto
                {
                    TaskId = t.TaskId,
                    IsCorrect = t.IsCorrect,
                    StudentAnswer = t.StudentAnswer,
                    Formula = t.Formula,
                    CorrectAnswer = t.CorrectAnswer,
                }).ToList()
            }).ToList();
        }

        public async Task<List<StudentWithResultsDTO>> GetExamResultsForAllStudents()
        {
            var students = await this.context.Students
                                            .Include(s => s.ExamResults)
                                            .ToListAsync();

            return students.Select(s => new StudentWithResultsDTO
            {
                Id = s.Id,
                Name = s.Name,
                Results = s.ExamResults.Select(er => new ExamResultDTO
                {
                    ExamId = er.ExamId,
                    Score = er.Score
                }).ToList()
            }).ToList();
        }
    }
}