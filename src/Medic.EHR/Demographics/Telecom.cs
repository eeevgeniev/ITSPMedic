using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    [Serializable]
    public class Telecom
    {
        [XmlElement(ElementName = Constants.TelecomAddress)]
        [JsonProperty(Constants.TelecomAddress)]
        public URI TelecomAddress { get; set; }

        [XmlElement(ElementName = Constants.Use)]
        [JsonProperty(Constants.Use)]
        public CS Use { get; set; }

        [XmlElement(ElementName = Constants.ValidTimeTelecome)]
        [JsonProperty(Constants.ValidTimeTelecome)]
        public IVLTS ValidTime { get; set; }
    }
}
