namespace MathTestSystem.DTOs
{
    public class ExamResultDto
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int ExamId { get; set; }
        public double Score { get; set; }
        public List<ExamTaskResultDto> ExamTasks { get; set; }
    }
}
