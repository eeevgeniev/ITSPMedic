using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Chairman
    {
        [XmlElement(ElementName = "Spec")]
        public string Speciality { get; set; }

        [XmlElement(ElementName = "UIN")]
        public string UniqueIdentifier { get; set; }

        [XmlElement(ElementName = "DoctorName")]
        public string DoctorName { get; set; }
    }
}