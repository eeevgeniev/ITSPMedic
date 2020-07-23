using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Medic.EHR.RM.Base
{
    [Serializable]
    public abstract class Item : RecordComponent
    {
        [XmlElement(ElementName = Constants.Emphasis)]
        [JsonProperty(Constants.Emphasis)]
        public CV Emphasis { get; set; }

        [XmlElement(ElementName = Constants.ObsTime)]
        [JsonProperty(Constants.ObsTime)]
        public IVLTS ObsTime { get; set; }

        [XmlElement(ElementName = Constants.ItemCategory)]
        [JsonProperty(Constants.ItemCategory)]
        public CS ItemCategory { get; set; }
    }
}
