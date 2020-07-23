using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class PQ : Quantity
    {
        [XmlElement(ElementName = Constants.Value)]
        [JsonProperty(Constants.Value)]
        public double Value { get; set; }

        [XmlElement(ElementName = Constants.Units)]
        [JsonProperty(Constants.Units)]
        public CS Units { get; set; }

        [XmlElement(ElementName = Constants.Property)]
        [JsonProperty(Constants.Property)]
        public CD Property { get; set; }

        [XmlElement(ElementName = Constants.Precision)]
        [JsonProperty(Constants.Precision)]
        public int? Precision { get; set; }
    }
}
