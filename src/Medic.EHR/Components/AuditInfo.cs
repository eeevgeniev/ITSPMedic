using Medic.EHR.Complexes;
using Medic.EHR.Primitives;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class AuditInfo<T>
    {
        [XmlElement(ElementName = "committer")]
        public InstanceIdentifier<T> Committer { get; set; }

        [XmlElement(ElementName = "audit_event_id")]
        public CodedValue<T> AuditEventId { get; set; }

        [XmlElement(ElementName = "audit_event_action_code")]
        public CodedSimple AuditEventActionCode { get; set; }

        [XmlElement(ElementName = "audit_event_timestamp")]
        public EHRDateTime AuditEventTimeStamp { get; set; }

        [XmlElement(ElementName = "audit_source_id")]
        public InstanceIdentifier<T> AuditSourceId { get; set; }
    }
}
