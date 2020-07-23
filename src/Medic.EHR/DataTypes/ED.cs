using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class ED : DataValue
    {
        [XmlElement(ElementName = Constants.MediaType)]
        [JsonProperty(Constants.MediaType)]
        public CS MediaType { get; set; }

        [XmlElement(ElementName = Constants.Charset)]
        [JsonProperty(Constants.Charset)]
        public CS Charset { get; set; }

        [XmlElement(ElementName = Constants.Language)]
        [JsonProperty(Constants.Language)]
        public CS Language { get; set; }

        [XmlElement(ElementName = Constants.Size)]
        [JsonProperty(Constants.Size)]
        public int? Size { get; set; }

        [XmlElement(ElementName = Constants.Compression)]
        [JsonProperty(Constants.Compression)]
        public CS Compression { get; set; }

        [XmlElement(ElementName = Constants.Reference)]
        [JsonProperty(Constants.Reference)]
        public URI Reference { get; set; }

        [XmlElement(ElementName = Constants.IntegrityCheck)]
        [JsonProperty(Constants.IntegrityCheck)]
        public string IntegrityCheck { get; set; }

        [XmlElement(ElementName = Constants.IntegrityCheckAlgorithm)]
        [JsonProperty(Constants.IntegrityCheckAlgorithm)]
        public CS IntegrityCheckAlgorithm { get; set; }

        [XmlElement(ElementName = Constants.Thumbnail)]
        [JsonProperty(Constants.Thumbnail)]
        public ED Thumbnail { get; set; }

        [XmlElement(ElementName = Constants.Data)]
        [JsonProperty(Constants.Data)]
        public string Data { get; set; }

        [XmlElement(ElementName = Constants.AlternateString)]
        [JsonProperty(Constants.AlternateString)]
        public SimpleText AlternateString { get; set; }
    }
}
