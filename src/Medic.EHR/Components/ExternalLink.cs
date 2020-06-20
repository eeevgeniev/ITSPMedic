using Medic.EHR.Complexes;
using Medic.EHR.Infrastructure;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    [Serializable]
    public class ExternalLink : Link
    {
        [XmlElement(ElementName = Constants.TargetSystem)]
        public InstanceIdentifier TargetSystem { get; set; }

        [XmlElement(ElementName = Constants.TargetInformationType)]
        public CodedSimple TargetInformationType { get; set; }
    }
}
