namespace MathTestSystem.Domain.Entites
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int TeacherId { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
