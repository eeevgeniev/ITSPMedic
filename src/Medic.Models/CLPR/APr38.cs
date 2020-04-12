using Medic.Models.CP;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class APr38
    {
        [XmlElement(ElementName = "height")]
        public int Height { get; set; }

        [XmlElement(ElementName = "weight")]
        public int Weight { get; set; }

        [XmlElement(ElementName = "history")]
        public string History { get; set; }

        [XmlElement(ElementName = "fairCondition")]
        public string FairCondition { get; set; }

        [XmlElement(ElementName = "therapy")]
        public string Therapy { get; set; }

        [XmlElement(ElementName = "Decision")]
        public Evaluation Decision { get; set; }
    }
}
