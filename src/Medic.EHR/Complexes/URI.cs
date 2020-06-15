using Medic.EHR.Primitives;
using System.Xml.Serialization;

namespace Medic.EHR.Complexes
{
    public class URI : EHRString
    {
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
    }
}
