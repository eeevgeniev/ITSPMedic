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
    public class Entry : Content
    {
        [XmlElement(ElementName = Constants.ActId)]
        [JsonProperty(Constants.ActId)]
        public string ActId { get; set; }

        [XmlElement(ElementName = Constants.ActStatus)]
        [JsonProperty(Constants.ActStatus)]
        public CS ActStatus { get; set; }

        [XmlElement(ElementName = Constants.UncertaintyExpressed)]
        [JsonProperty(Constants.UncertaintyExpressed)]
        public bool UncertaintyExpressed { get; set; } = false;

        [XmlElement(ElementName = Constants.SubjectOfInformationCategory)]
        [JsonProperty(Constants.SubjectOfInformationCategory)]
        public CS SubjectOfInformationCategory { get; set; }

        [XmlElement(ElementName = Constants.InfoProvider)]
        [JsonProperty(Constants.InfoProvider)]
        public FunctionalRole InfoProvider { get; set; }

        [XmlElement(ElementName = Constants.SubjectOfInformation)]
        [JsonProperty(Constants.SubjectOfInformation)]
        public RelatedParty SubjectOfInformation { get; set; }

        [XmlElement(ElementName = Constants.OtherParticipations)]
        [JsonProperty(Constants.OtherParticipations)]
        public List<FunctionalRole> OtherParticipations { get; set; }

        [XmlElement(ElementName = Constants.Items)]
        [JsonProperty(Constants.Items)]
        public List<Item> Items { get; set; }
    }
}
