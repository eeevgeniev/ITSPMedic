using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class Duration : Quantity
    {
        [XmlElement(ElementName = Constants.Days)]
        [JsonProperty(Constants.Days)]
        public int? Days { get; set; }

        [XmlElement(ElementName = Constants.Hours)]
        [JsonProperty(Constants.Hours)]
        public int? Hours { get; set; }

        [XmlElement(ElementName = Constants.Minutes)]
        [JsonProperty(Constants.Minutes)]
        public int? Minutes { get; set; }

        [XmlElement(ElementName = Constants.Seconds)]
        [JsonProperty(Constants.Seconds)]
        public int? Seconds { get; set; }

        [XmlElement(ElementName = Constants.FractionalSecond)]
        [JsonProperty(Constants.FractionalSecond)]
        public double? FractionalSecond { get; set; }

        [XmlElement(ElementName = Constants.Sign)]
        [JsonProperty(Constants.Sign)]
        public int? Sign { get; set; }
    }
}
