using Medic.EHR.Components;
using Medic.EHR.Demographics.Base;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    public class DemographicEntity<T> : StructureComponent<T>
    {
        [XmlElement(ElementName = "items")]
        public List<DemographicItem<T>> Items { get; set; }
    }
}
