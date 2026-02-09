namespace MathTestSystem.UI.DTOs
{
    public class ExamTaskResultDTO
    {
        public int TaskId { get; set; }
        public string Formula { get; set; }
        public bool IsCorrect { get; set; }
        public string StudentAnswer { get; set; }
        public string CorrectAnswer { get; set; }
    }

}
