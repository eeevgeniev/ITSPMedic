using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.RM.Base
{
    [Serializable]
    public abstract class RecordComponent
    {
        [XmlElement(ElementName = Constants.Name)]
        [JsonProperty(Constants.Name)]
        public Text Name { get; set; }

        [XmlElement(ElementName = Constants.ArchetypeId)]
        [JsonProperty(Constants.ArchetypeId)]
        public string ArchetypeId { get; set; }

        [XmlElement(ElementName = Constants.RcId)]
        [JsonProperty(Constants.RcId)]
        public II RcId { get; set; }

        [XmlElement(ElementName = Constants.Meaning)]
        [JsonProperty(Constants.Meaning)]
        public CV Meaning { get; set; }

        [XmlElement(ElementName = Constants.Synthesised)]
        [JsonProperty(Constants.Synthesised)]
        public bool Synthesised { get; set; } = false;

        [XmlElement(ElementName = Constants.PolicyIds)]
        [JsonProperty(Constants.PolicyIds)]
        public List<II> PolicyIds { get; set; }

        [XmlElement(ElementName = Constants.Sensitivity)]
        [JsonProperty(Constants.Sensitivity)]
        public int? Sensitivity { get; set; }

        [XmlElement(ElementName = Constants.OrigParentRef)]
        [JsonProperty(Constants.OrigParentRef)]
        public II OrigParentRef { get; set; }

        [XmlElement(ElementName = Constants.Links)]
        [JsonProperty(Constants.Links)]
        public List<Link> Links { get; set; }

        [XmlElement(ElementName = Constants.FeederAudit)]
        [JsonProperty(Constants.FeederAudit)]
        public AuditInfo FeederAudit { get; set; }
    }
}
