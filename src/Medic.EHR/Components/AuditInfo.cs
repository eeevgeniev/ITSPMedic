using Medic.EHR.Complexes;
using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    [Serializable]
    public class AuditInfo
    {
        [XmlElement(ElementName = Constants.Committer)]
        public InstanceIdentifier Committer { get; set; }

        [XmlElement(ElementName = Constants.AuditEventId)]
        public CodedValue AuditEventId { get; set; }

        [XmlElement(ElementName = Constants.AuditEventActionCode)]
        public CodedSimple AuditEventActionCode { get; set; }

        [XmlElement(ElementName = Constants.AuditEventTimeStamp)]
        public EHRDateTime AuditEventTimeStamp { get; set; }

        [XmlElement(ElementName = Constants.AuditSourceId)]
        public InstanceIdentifier AuditSourceId { get; set; }
    }
}
