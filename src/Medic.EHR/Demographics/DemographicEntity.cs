using Medic.EHR.Components;
using Medic.EHR.Demographics.Base;
using Medic.EHR.Infrastructure;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    public class DemographicEntity<T> : StructureComponent<T>
    {
        [XmlElement(ElementName = Constants.Items)]
        public List<DemographicItem<T>> Items { get; set; }
    }
}
