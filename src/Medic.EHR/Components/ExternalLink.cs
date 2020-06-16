using Medic.EHR.Complexes;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class ExternalLink<T> : Link<T>
    {
        [XmlElement(ElementName = Constants.TargetSystem)]
        public InstanceIdentifier<T> TargetSystem { get; set; }

        [XmlElement(ElementName = Constants.TargetInformationType)]
        public CodedSimple TargetInformationType { get; set; }
    }
}
