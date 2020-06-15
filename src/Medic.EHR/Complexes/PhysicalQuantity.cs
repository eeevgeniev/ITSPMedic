using Medic.EHR.Primitives;
using System.Xml.Serialization;

namespace Medic.EHR.Complexes
{
    public class PhysicalQuantity : EHRReal
    {
        [XmlElement(ElementName = "unit")]
        public CodedSimple Unit { get; set; }
    }
}
