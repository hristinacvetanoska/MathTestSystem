namespace MathTestSystem.Domain.Entites
{
    public class ExamResult
    {
        public int Id { get; set; }
        public int TotalTasks { get; set; }
        public int CorrectTasks { get; set; }
        public int IncorrectTasks { get; set; }
        public double Score { get; set; }
    }
}
