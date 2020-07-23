using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class CR
    {
        [XmlElement(ElementName = Constants.Inverted)]
        [JsonProperty(Constants.Inverted)]
        public bool? Inverted { get; set; } 

        [XmlElement(ElementName = Constants.QualCode)]
        [JsonProperty(Constants.QualCode)]
        public CV QualCode { get; set; }

        [XmlElement(ElementName = Constants.Role)]
        [JsonProperty(Constants.Role)]
        public CV Role { get; set; }
    }
}
