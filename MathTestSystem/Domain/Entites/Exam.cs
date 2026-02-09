namespace MathTestSystem.Domain.Entites
{
    using System.Xml.Serialization;

    public class Exam
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlElement("Task")]
        public List<MathTask> MathTasks { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
    }
}
