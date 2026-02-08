namespace MathTestSystem.Domain.Entites
{
    public class Exam
    {
        public int Id { get; set; }
        public List<MathTask> MathTasks { get; set; }
        public int StudentId { get; set; }
        public ExamResult Result { get; set; }
    }
}
