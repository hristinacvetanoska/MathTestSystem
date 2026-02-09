namespace MathTestSystem.Domain.Entites
{
    using System.ComponentModel.DataAnnotations;

    public class ExamTaskResult
    {
        [Key]
        public int Id { get; set; }
        public bool IsCorrect { get; set; }
        public int TaskId { get; set; }
        public string CorrectAnswer { get; set; }
        public string StudentAnswer { get; set; }
        public string Formula { get; set; }
        public int ExamResultId { get; set; }
        public ExamResult ExamResult { get; set; }
        public ExamTaskResult() { }
        public ExamTaskResult(int taskId, bool isCorrect, string correctAnswer, string actualAnswer, string formula)
        {
            TaskId = taskId;
            IsCorrect = isCorrect;
            CorrectAnswer = correctAnswer;
            StudentAnswer = actualAnswer;
            Formula = formula;
        }
    }
}
