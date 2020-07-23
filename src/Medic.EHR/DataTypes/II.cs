using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class II : DataValue
    {
        [XmlElement(ElementName = Constants.Extension)]
        [JsonProperty(Constants.Extension)]
        public string Extension { get; set; }

        [XmlElement(ElementName = Constants.AssigningAuthorityName)]
        [JsonProperty(Constants.AssigningAuthorityName)]
        public string AssigningAuthorityName { get; set; }

        [XmlElement(ElementName = Constants.ValidTime)]
        [JsonProperty(Constants.ValidTime)]
        public IVLTS ValidTime { get; set; }

        [XmlElement(ElementName = Constants.Root)]
        [JsonProperty(Constants.Root)]
        public OID Root { get; set; }
    }
}
