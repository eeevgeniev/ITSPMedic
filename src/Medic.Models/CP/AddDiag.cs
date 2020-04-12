using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class AddDiag
    {
        [XmlElement(ElementName = "imeMD")]
        public string ImeMD { get; set; }

        [XmlElement(ElementName = "MKB")]
        public string MKB { get; set; }
    }
}