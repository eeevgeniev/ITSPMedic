using Medic.EHR.Complexes;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class ExternalLink<T> : Link<T>
    {
        [XmlElement(ElementName = "target_system")]
        public InstanceIdentifier<T> TargetSystem { get; set; }

        [XmlElement(ElementName = "target_information_type")]
        public CodedSimple TargetInformationType { get; set; }
    }
}
