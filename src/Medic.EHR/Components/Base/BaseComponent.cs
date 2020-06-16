using Medic.EHR.Complexes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Components.Base
{
    public abstract class BaseComponent<T>
    {
        [XmlElement(ElementName = "rc_id")]
        public InstanceIdentifier<T> RcId { get; set; }

        [XmlElement(ElementName = "previous_version")]
        public InstanceIdentifier<T> PreviousVersion { get; set; }

        [XmlElement(ElementName = "version_set_id")]
        public InstanceIdentifier<T> VersionSetId { get; set; }

        [XmlElement(ElementName = "version_status")]
        public CodedValue<T> VersionStatus { get; set; }

        [XmlElement(ElementName = "reason_for_revision")]
        public CodedValue<T> ReasonForRevision { get; set; }

        [XmlElement(ElementName = "audits")]
        public List<AuditInfo<T>> Audits { get; set; }
    }
}
