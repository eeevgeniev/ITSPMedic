using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Complexes
{
    [Serializable]
    public class PhysicalQuantity : EHRReal
    {
        [XmlElement(ElementName = Constants.Unit)]
        public CodedSimple Unit { get; set; }
    }
}
