using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Diag
    {
        [XmlElement(ElementName = "imeMD")]
        public string ImeMD { get; set; }

        [XmlElement(ElementName = "MKB")]
        public string MKB { get; set; }

        [XmlElement(ElementName = "imeLinkD")]
        public string LinkDName { get; set; }

        [XmlElement(ElementName = "MKBLinkD")]
        public string LinkDMKB { get; set; }
    }
}
