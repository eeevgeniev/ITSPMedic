using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class CeasedClinical
    {
        [XmlElement(ElementName = "code")]
        public string Code { get; set; }

        [XmlElement(ElementName = "IZMedicalWard")]
        public int IZMedicalWard { get; set; }

        [XmlElement(ElementName = "IZYearMedicalWard")]
        public int IZYearMedicalWard { get; set; }
    }
}
