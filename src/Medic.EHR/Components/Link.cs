using Medic.EHR.Complexes;
using Medic.EHR.Components.Base;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class Link<T> : BaseComponent<T>
    {
        [XmlElement(ElementName = "link_description")]
        public CodedValue<T> LinkDescription { get; set; }

        [XmlElement(ElementName = "target")]
        public InstanceIdentifier<T> Target { get; set; }

        [XmlElement(ElementName = "source")]
        public InstanceIdentifier<T> Source { get; set; }
    }
}