using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Practice
    {
        [XmlElement(ElementName = "branch")]
        public string Branch { get; set; }

        [XmlElement(ElementName = "no")]
        public string Number { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "healthRegion")]
        public string HealthRegion { get; set; }

        [XmlElement(ElementName = "address", IsNullable = false)]
        public string Address { get; set; }
    }
}