using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Redirected
    {
        [XmlElement(ElementName = "Practice")]
        public Practice Practice { get; set; }

        [XmlElement(ElementName = "Diagnose")]
        public Diagnose Diagnose { get; set; }
    }
}
