using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Choise
    {
        [XmlElement(ElementName = "No")]
        public int Number { get; set; }

        public int Checked { get; set; }

        public string Text { get; set; }
    }
}
