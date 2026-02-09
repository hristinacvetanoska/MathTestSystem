namespace MathTestSystem.Domain.Entites
{
    using System.Xml.Serialization;
    public class MathTask
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlText]
        public string Formula { get; set; }
        public double StudentAnwer { get; set; }
        public double CorrectAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
