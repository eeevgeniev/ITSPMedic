using Medic.EHR.Complexes;
using Medic.EHR.Components.Base;
using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class AttestationInfo<T> : BaseComponent<T>
    {
        [XmlElement(ElementName = Constants.TargetComponent)]
        public InstanceIdentifier<T> TargetComponent { get; set; }

        [XmlElement(ElementName = Constants.Time)]
        public EHRTime Time { get; set; }

        [XmlElement(ElementName = Constants.Proof)]
        public Attachment Proof { get; set; }

        [XmlElement(ElementName = Constants.AttestedView)]
        public Attachment AttestedView { get; set; }

        [XmlElement(ElementName = Constants.ReasonForAttestation)]
        public CodedValue<T> ReasonForAttestation { get; set; }

        [XmlElement(ElementName = Constants.Attester)]
        public InstanceIdentifier<T> Attester { get; set; }

        [XmlElement(ElementName = Constants.AttestationMeans)]
        public CodedSimple AttestationMeans { get; set; }
    }
}
