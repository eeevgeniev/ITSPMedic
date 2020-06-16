using Medic.EHR.Demographics.Base;
using Medic.EHR.Infrastructure;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    public class DemographicCluster<T> : DemographicItem<T>
    {
        [XmlElement(ElementName = Constants.Parts)]
        public List<DemographicItem<T>> Parts { get; set; }
    }
}
