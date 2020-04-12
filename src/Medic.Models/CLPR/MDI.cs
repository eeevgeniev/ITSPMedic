using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class MDI
    {
        [XmlElement(ElementName = "imeMDI")]
        public string MDIName { get; set; }

        [XmlElement(ElementName = "kodMDI")]
        public decimal MDICode {get; set;}
    }
}
