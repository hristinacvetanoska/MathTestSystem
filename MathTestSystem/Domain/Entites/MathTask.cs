namespace MathTestSystem.Domain.Entites
{
    using System.Xml.Serialization;
    public class MathTask
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlText]
        public string Formula { get; set; }
        public double ExpectedResult { get; set; }
        public double ActualResult { get; set; }
        public bool IsCorrect { get; set; }
    }
}
