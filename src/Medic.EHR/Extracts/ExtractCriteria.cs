using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Extracts
{
    [Serializable]
    public class ExtractCriteria
    {
        [XmlElement(ElementName = Constants.TimePeriod)]
        [JsonProperty(Constants.TimePeriod)]
        public IVLTS TimePeriod { get; set; }

        [XmlElement(ElementName = Constants.MaxSensitivity)]
        [JsonProperty(Constants.MaxSensitivity)]
        public int? MaxSensitivity { get; set; }

        [XmlElement(ElementName = Constants.AllVersions)]
        [JsonProperty(Constants.AllVersions)]
        public bool? AllVersions { get; set; }

        [XmlElement(ElementName = Constants.MultimediaIncluded)]
        [JsonProperty(Constants.MultimediaIncluded)]
        public bool? MultimediaIncluded { get; set; }

        [XmlElement(ElementName = Constants.ArchetypeIds)]
        [JsonProperty(Constants.ArchetypeIds)]
        public II ArchetypeIds { get; set; }

        [XmlElement(ElementName = Constants.OtherConstraints)]
        [JsonProperty(Constants.OtherConstraints)]
        public string OtherConstraints { get; set; }
    }
}
