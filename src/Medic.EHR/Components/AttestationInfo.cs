using Medic.EHR.Complexes;
using Medic.EHR.Components.Base;
using Medic.EHR.Primitives;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class AttestationInfo<T> : BaseComponent<T>
    {
        [XmlElement(ElementName = "target_component")]
        public InstanceIdentifier<T> TargetComponent { get; set; }

        [XmlElement(ElementName = "time")]
        public EHRTime Time { get; set; }

        [XmlElement(ElementName = "proof")]
        public Attachment Proof { get; set; }

        [XmlElement(ElementName = "attested_view")]
        public Attachment AttestedView { get; set; }

        [XmlElement(ElementName = "reason_for_attestation")]
        public CodedValue<T> ReasonForAttestation { get; set; }

        [XmlElement(ElementName = "attester")]
        public InstanceIdentifier<T> Attester { get; set; }

        [XmlElement(ElementName = "attestation_means")]
        public CodedSimple AttestationMeans { get; set; }
    }
}
