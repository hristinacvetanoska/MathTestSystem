namespace MathTestSystem.DTOs
{
    public class ExamTaskResultDto
    {
        public bool IsCorrect { get; set; }
        public string CorrectAnswer { get; set; }
        public string StudentAnswer { get; set; }
        public string Formula { get; set; }
        public int TaskId { get; set; }
    }
}
