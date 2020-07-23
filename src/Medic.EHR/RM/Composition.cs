using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using Medic.EHR.RM.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    [Serializable]
    public class Composition : RecordComponent
    {
        [XmlElement(ElementName = Constants.SessionTime)]
        [JsonProperty(Constants.SessionTime)]
        public IVLTS SessionTime { get; set; }

        [XmlElement(ElementName = Constants.Territory)]
        [JsonProperty(Constants.Territory)]
        public CS Territory { get; set; }

        [XmlElement(ElementName = Constants.ContributionId)]
        [JsonProperty(Constants.ContributionId)]
        public II ContributionId { get; set; }

        [XmlElement(ElementName = Constants.Committal)]
        [JsonProperty(Constants.Committal)]
        public AuditInfo Committal { get; set; }

        [XmlElement(ElementName = Constants.Composer)]
        [JsonProperty(Constants.Composer)]
        public FunctionalRole Composer { get; set; }

        [XmlElement(ElementName = Constants.OtherParticipation)]
        [JsonProperty(Constants.OtherParticipation)]
        public List<FunctionalRole> OtherParticipation { get; set; }

        [XmlElement(ElementName = Constants.Attestations)]
        [JsonProperty(Constants.Attestations)]
        public List<AttestationInfo> Attestations { get; set; }

        [XmlElement(ElementName = Constants.Content)]
        [JsonProperty(Constants.Content)]
        public List<Content> Content { get; set; }
    }
}
