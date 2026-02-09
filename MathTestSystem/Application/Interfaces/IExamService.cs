namespace MathTestSystem.Application.Interfaces
{
    using MathTestSystem.Domain.Entites;
    using MathTestSystem.DTOs;

    public interface IExamService
    {
        Task<Dictionary<int, ExamResult>> ReadXMLContent(string xmlContent);
        Task<ExamResult> ProcessExam(Exam exam, int studentId, int teacherId);
        Task<List<ExamResultDTO>> GetExamResultByStudent(int studentId);
        Task<List<StudentWithResultsDTO>> GetExamResultsForAllStudents();
    }
}
