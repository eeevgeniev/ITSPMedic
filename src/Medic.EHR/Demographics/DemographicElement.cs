using Medic.EHR.Demographics.Base;
using Medic.EHR.Primitives.Base;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    [Serializable]
    public class DemographicElement : DemographicItem
    {
        [XmlElement(ElementName = "value")]
        public EHRDataValue DataValue { get; set; }
    }
}
