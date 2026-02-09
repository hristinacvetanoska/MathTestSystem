using System.Xml.Serialization;

namespace MathTestSystem.Domain.Entites
{
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
