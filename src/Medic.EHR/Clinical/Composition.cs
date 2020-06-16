using Medic.EHR.Clinical.Base;
using Medic.EHR.Complexes;
using Medic.EHR.Components;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    public class Composition<T> : StructureComponent<T>
    {
        [XmlElement(ElementName = "composer")]
        public InstanceIdentifier<T> Composer { get; set; }

        [XmlElement(ElementName = "policy_ids")]
        public List<InstanceIdentifier<T>> PolicyIds { get; set; }

        [XmlElement(ElementName = "content")]
        public List<Content<T>> Content { get; set; }

        [XmlAttribute(AttributeName = "sensitivity")]
        public int? Sensitivity { get; set; }
    }
}
