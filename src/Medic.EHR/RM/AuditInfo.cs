using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    [Serializable]
    public class AuditInfo
    {
        [XmlElement(ElementName = Constants.EhrSystem)]
        public II EhrSystem { get; set; }

        [XmlElement(ElementName = Constants.TimeCommitted)]
        public TS TimeCommitted { get; set; }

        [XmlElement(ElementName = Constants.Committer)]
        public II Committer { get; set; }

        [XmlElement(ElementName = Constants.VersionStatus)]
        public CS VersionStatus { get; set; }

        [XmlElement(ElementName = Constants.ReasonForRevision)]
        public CV ReasonForRevision { get; set; }

        [XmlElement(ElementName = Constants.PreviousVersion)]
        public II PreviousVersion { get; set; }

        [XmlElement(ElementName = Constants.VersionSetId)]
        public II VersionSetId { get; set; }
    }
}
