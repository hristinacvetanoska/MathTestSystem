namespace MathTestSystem.DTOs
{
    public class StudentWithResultsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExamResultDTO> Results { get; set; }
    }
}
