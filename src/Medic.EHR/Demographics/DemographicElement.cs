using Medic.EHR.Demographics.Base;
using Medic.EHR.Primitives.Base;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    public class DemographicElement<T> : DemographicItem<T>
    {
        [XmlElement(ElementName = "value")]
        public EHRDataValue<T> DataValue { get; set; }
    }
}
