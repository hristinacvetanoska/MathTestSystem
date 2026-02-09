namespace MathTestSystem.UI.DTOs
{
    public class ExamResultDTO
    {
        public int ExamId { get; set; }
        public int TotalTasks { get; set; }
        public int CorrectTasks { get; set; }
        public double Score { get; set; }
        public List<ExamTaskResultDTO> ExamTasks { get; set; }
    }
}
