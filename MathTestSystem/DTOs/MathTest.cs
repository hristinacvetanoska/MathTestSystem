namespace MathTestSystem.DTOs
{
    public class MathTest
    {
        public int TeacherId { get; set; }
        public List<ExamTaskResultDto> Exams { get; set; }
        public List<StudentDTOs> StudentDTOs { get; set; }
    }
}
