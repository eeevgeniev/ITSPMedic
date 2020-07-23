using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class OID
    {
        [XmlElement(ElementName = Constants.Oid)]
        [JsonProperty(Constants.Oid)]
        public string Oid { get; set; }
    }
}
