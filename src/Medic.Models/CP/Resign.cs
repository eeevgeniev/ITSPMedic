using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Resign
    {
        [XmlElement(ElementName = "OutRefuse")]
        public int OutRefuse { get; set; }

        [XmlElement(ElementName = "Notes")]
        public string Notes { get; set; }
    }
}
