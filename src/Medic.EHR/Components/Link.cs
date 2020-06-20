using Medic.EHR.Complexes;
using Medic.EHR.Components.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    [Serializable]
    public class Link : BaseComponent
    {
        [XmlElement(ElementName = Constants.LinkDescription)]
        public CodedValue LinkDescription { get; set; }

        [XmlElement(ElementName = Constants.Target)]
        public InstanceIdentifier Target { get; set; }

        [XmlElement(ElementName = Constants.Source)]
        public InstanceIdentifier Source { get; set; }
    }
}