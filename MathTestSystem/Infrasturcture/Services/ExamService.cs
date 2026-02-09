namespace MathTestSystem.Infrasturcture.Services
{
    using MathTestSystem.Application.Interfaces;
    using MathTestSystem.Domain.Entites;
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
            await context.ExamTaskResults.ExecuteDeleteAsync();
            await context.ExamResults.ExecuteDeleteAsync();
            //var examResult = new ExamResult();
            //var listResults = new List<ExamResult>();
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
                task.ExpectedResult = Convert.ToDouble(mathOperation[1].Trim());
                task.ActualResult = this.mathService.Evaluate(mathOperation[0].Trim());
                task.IsCorrect = this.mathService.CheckAnswer(task.ActualResult, task.ExpectedResult);

                var taskResult = new ExamTaskResult
                {
                    TaskId = task.Id,
                    IsCorrect = task.IsCorrect,
                    ExamResult = examResult
                };
                examResult.ExamTasks.Add(taskResult);
            }

            examResult.CorrectTasks = exam.MathTasks.Count(t => t.IsCorrect);
            examResult.Score = exam.MathTasks.Count(t => t.IsCorrect) * 100.0 / exam.MathTasks.Count;
            return examResult;
        }
    }
}
