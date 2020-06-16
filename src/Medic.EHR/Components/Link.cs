using Medic.EHR.Complexes;
using Medic.EHR.Components.Base;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class Link<T> : BaseComponent<T>
    {
        [XmlElement(ElementName = Constants.LinkDescription)]
        public CodedValue<T> LinkDescription { get; set; }

        [XmlElement(ElementName = Constants.Target)]
        public InstanceIdentifier<T> Target { get; set; }

        [XmlElement(ElementName = Constants.Source)]
        public InstanceIdentifier<T> Source { get; set; }
    }
}