namespace MathTestSystem.DTOs
{
    public class ExamResultDTO
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int ExamId { get; set; }
        public double Score { get; set; }
        public int TotalTasks { get; set; }
        public int CorrectTasks { get; set; }
        public List<ExamTaskResultDto> ExamTasks { get; set; }
    }
}
