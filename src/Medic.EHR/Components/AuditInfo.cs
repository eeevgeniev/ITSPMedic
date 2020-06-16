using Medic.EHR.Complexes;
using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class AuditInfo<T>
    {
        [XmlElement(ElementName = Constants.Committer)]
        public InstanceIdentifier<T> Committer { get; set; }

        [XmlElement(ElementName = Constants.AuditEventId)]
        public CodedValue<T> AuditEventId { get; set; }

        [XmlElement(ElementName = Constants.AuditEventActionCode)]
        public CodedSimple AuditEventActionCode { get; set; }

        [XmlElement(ElementName = Constants.AuditEventTimeStamp)]
        public EHRDateTime AuditEventTimeStamp { get; set; }

        [XmlElement(ElementName = Constants.AuditSourceId)]
        public InstanceIdentifier<T> AuditSourceId { get; set; }
    }
}
