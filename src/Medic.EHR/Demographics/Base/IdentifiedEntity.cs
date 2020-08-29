using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    [Serializable]
    public abstract class IdentifiedEntity
    {
        [XmlElement(ElementName = Constants.ExtractId)]
        [JsonProperty(Constants.ExtractId)]
        public II ExtractId { get; set; }

        [XmlElement(ElementName = Constants.Id)]
        [JsonProperty(Constants.Id)]
        public II Id { get; set; }

        [XmlElement(ElementName = Constants.Telecom)]
        [JsonProperty(Constants.Telecom)]
        public Telecom Telecom { get; set; }
    }
}
