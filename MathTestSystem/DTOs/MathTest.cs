namespace MathTestSystem.DTOs
{
    public class MathTest
    {
        public int TeacherId { get; set; }
        public List<ExamDTOs> Exams { get; set; }
        public List<StudentDTOs> StudentDTOs { get; set; }
    }
}
