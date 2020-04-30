using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class Sender
    {
        [XmlAttribute(AttributeName = "SenderType")]
        public int SenderType { get; set; }

        [XmlElement(ElementName = "ZdrRajon")]
        public int? HealthRegion { get; set; }

        [XmlElement(ElementName = "PracticeCode")]
        public string PracticeCode { get; set; }

        [XmlElement(ElementName = "UIN")]
        public string UniqueIdentifier { get; set; }

        [XmlElement(ElementName = "PracticeName")]
        public string PracticeName { get; set; }

        [XmlElement(ElementName = "DoctorName")]
        public string DoctorName { get; set; }
    }
}
