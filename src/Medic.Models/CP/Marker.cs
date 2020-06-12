using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Marker
    {
        [XmlElement(ElementName = "No")]
        public int? Number { get; set; }

        [XmlElement(ElementName = "Sign")]
        public int Sign { get; set; }
    }
}
