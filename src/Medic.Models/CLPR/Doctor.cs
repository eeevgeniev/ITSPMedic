using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class Doctor
    {
        [XmlElement(ElementName = "UIN_Doc")]
        public string UniqueIdentifier { get; set; }

        [XmlElement(ElementName = "Name_Doc")]
        public string Name { get; set; }

        [XmlElement(ElementName = "CodeSpec")]
        public int SpecialtyCode { get; set; }
    }
}
