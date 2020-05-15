using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Histology
    {
        [XmlElement(ElementName = "NameHS")]
        public string NameHS { get; set; }

        [XmlElement(ElementName = "CodeHS")]
        public string CodeHS { get; set; }
    }
}