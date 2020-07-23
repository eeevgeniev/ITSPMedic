using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    [Serializable]
    public class AuditInfo
    {
        [XmlElement(ElementName = Constants.EhrSystem)]
        [JsonProperty(Constants.EhrSystem)]
        public II EhrSystem { get; set; }

        [XmlElement(ElementName = Constants.TimeCommitted)]
        [JsonProperty(Constants.TimeCommitted)]
        public TS TimeCommitted { get; set; }

        [XmlElement(ElementName = Constants.Committer)]
        [JsonProperty(Constants.Committer)]
        public II Committer { get; set; }

        [XmlElement(ElementName = Constants.VersionStatus)]
        [JsonProperty(Constants.VersionStatus)]
        public CS VersionStatus { get; set; }

        [XmlElement(ElementName = Constants.ReasonForRevision)]
        [JsonProperty(Constants.ReasonForRevision)]
        public CV ReasonForRevision { get; set; }

        [XmlElement(ElementName = Constants.PreviousVersion)]
        [JsonProperty(Constants.PreviousVersion)]
        public II PreviousVersion { get; set; }

        [XmlElement(ElementName = Constants.VersionSetId)]
        [JsonProperty(Constants.VersionSetId)]
        public II VersionSetId { get; set; }
    }
}
