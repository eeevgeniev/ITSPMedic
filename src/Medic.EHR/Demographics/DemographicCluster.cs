using Medic.EHR.Demographics.Base;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    public class DemographicCluster<T> : DemographicItem<T>
    {
        [XmlElement(ElementName = "parts")]
        public List<DemographicItem<T>> Parts { get; set; }
    }
}
