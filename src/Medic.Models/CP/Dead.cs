using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Dead
    {
        [XmlElement(ElementName = "primary")]
        public string Primary { get; set; }
    }
}