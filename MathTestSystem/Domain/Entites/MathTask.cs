namespace MathTestSystem.Domain.Entites
{
    public class MathTask
    {
        public int Id { get; set; }
        public string MathOperation { get; set; }
        public string ExpectedResult { get; set; }
        public string ActualResult { get; set; }
        public bool IsCorrect { get; set; }
    }
}
