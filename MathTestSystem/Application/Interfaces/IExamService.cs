namespace MathTestSystem.Application.Interfaces
{
    using MathTestSystem.Domain.Entites;

    public interface IExamService
    {
        Task<Dictionary<int, ExamResult>> ReadXMLContent(string xmlContent);
        Task<ExamResult> ProcessExam(Exam exam, int studentId, int teacherId);
    }
}
