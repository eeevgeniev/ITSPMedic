using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class CeasedClinicalPath
    {
        [XmlElement(ElementName = "code")]
        public string Code { get; set; }

        [XmlElement(ElementName = "IZMedicalWard")]
        public int IZMedicalWard { get; set; }

        [XmlElement(ElementName = "IZYearMedicalWard")]
        public int IZYearMedicalWard { get; set; }
    }
}
