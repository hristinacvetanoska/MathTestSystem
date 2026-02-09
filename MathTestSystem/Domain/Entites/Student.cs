using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace MathTestSystem.Domain.Entites
{
    public class Student
    {
        [XmlAttribute("ID")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [XmlElement("Exam")]
        public Exam Exam { get; set; }
        public List<ExamResult> ExamResults { get; set; } = new List<ExamResult>();
    }
}
