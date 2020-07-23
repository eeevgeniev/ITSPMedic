using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes.Base
{
    [Serializable]
    public abstract class Text : DataValue
    {
        [XmlElement(ElementName = Constants.OriginalText)]
        [JsonProperty(Constants.OriginalText)]
        public string OriginalText { get; set; }

        [XmlElement(ElementName = Constants.Language)]
        [JsonProperty(Constants.Language)]
        public CS Language { get; set; }

        [XmlElement(ElementName = Constants.Charset)]
        [JsonProperty(Constants.Charset)]
        public CS Charset { get; set; }
    }
}