using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives;
using System.Xml.Serialization;

namespace Medic.EHR.Complexes
{
    public class PhysicalQuantity : EHRReal
    {
        [XmlElement(ElementName = Constants.Unit)]
        public CodedSimple Unit { get; set; }
    }
}
