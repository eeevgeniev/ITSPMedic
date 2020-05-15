using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Choice
    {
        [XmlElement(ElementName = "No")]
        public int Number { get; set; }

        [XmlElement(ElementName = "Checked")]
        public int Checked { get; set; }

        [XmlElement(ElementName = "Text")]
        public string Text { get; set; }
    }
}
