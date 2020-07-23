using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class URI : DataValue
    {
        [XmlElement(ElementName = Constants.Value)]
        [JsonProperty(Constants.Value)]
        public string Value { get; set; }

        [XmlElement(ElementName = Constants.Scheme)]
        [JsonProperty(Constants.Scheme)]
        public string Scheme { get; set; }

        [XmlElement(ElementName = Constants.Path)]
        [JsonProperty(Constants.Path)]
        public string Path { get; set; }

        [XmlElement(ElementName = Constants.FragmentId)]
        [JsonProperty(Constants.FragmentId)]
        public string FragmentId { get; set; }

        [XmlElement(ElementName = Constants.UriQuery)]
        [JsonProperty(Constants.UriQuery)]
        public string UriQuery { get; set; }

        [XmlElement(ElementName = Constants.Literal)]
        [JsonProperty(Constants.Literal)]
        public string Literal { get; set; }
    }
}
