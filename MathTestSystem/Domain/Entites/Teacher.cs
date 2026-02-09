namespace MathTestSystem.Domain.Entites
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlRoot("Teacher")]
    public class Teacher
    {
        [XmlAttribute("ID")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [XmlArray("Students")]
        [XmlArrayItem("Student")]
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
