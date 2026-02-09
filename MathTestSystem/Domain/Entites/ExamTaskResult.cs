using System.ComponentModel.DataAnnotations;

namespace MathTestSystem.Domain.Entites
{
    public class ExamTaskResult
    {
        [Key]
        public int Id { get; set; }
        public bool IsCorrect { get; set; }
        public int TaskId { get; set; }
        public int ExamResultId { get; set; }
        public ExamResult ExamResult { get; set; }
        public ExamTaskResult() { }
        public ExamTaskResult(int taskId, bool isCorrect)
        {
            TaskId = taskId;
            IsCorrect = isCorrect;
        }
    }
}
