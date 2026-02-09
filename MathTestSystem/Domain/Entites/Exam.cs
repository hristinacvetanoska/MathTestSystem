using System.Xml.Serialization;

namespace MathTestSystem.Domain.Entites
{
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
