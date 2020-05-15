using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Member
    {
        [XmlElement(ElementName = "Spec")]
        public int? Speciality { get; set; }

        [XmlElement(ElementName = "UIN")]
        public string UniqueIdentifier { get; set; }

        [XmlElement(ElementName = "DoctorName")]
        public string DoctorName { get; set; }
    }
}