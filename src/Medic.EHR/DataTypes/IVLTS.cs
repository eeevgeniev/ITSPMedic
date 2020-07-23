using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class IVLTS : DataValue
    {
        [XmlElement(ElementName = Constants.Low)]
        [JsonProperty(Constants.Low)]
        public TS Low { get; set; }

        [XmlElement(ElementName = Constants.High)]
        [JsonProperty(Constants.High)]
        public TS High { get; set; }

        [XmlElement(ElementName = Constants.LowClosed)]
        [JsonProperty(Constants.LowClosed)]
        public bool? LowClosed { get; set; }

        [XmlElement(ElementName = Constants.HighClosed)]
        [JsonProperty(Constants.HighClosed)]
        public bool? HighClosed { get; set; }

        [XmlElement(ElementName = Constants.Width)]
        [JsonProperty(Constants.Width)]
        public Duration Width { get; set; }
    }
}
