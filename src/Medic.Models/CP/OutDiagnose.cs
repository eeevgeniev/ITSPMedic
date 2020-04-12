using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class OutDiagnose
    {
        [XmlElement(ElementName = "primary")]
        public string Primary { get; set; }

        [XmlElement(ElementName = "secondary")]
        public string Secondary { get; set; }
    }
}
