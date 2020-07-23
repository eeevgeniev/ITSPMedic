using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class TS : DataValue
    {
        [XmlElement(ElementName = Constants.Time)]
        [JsonProperty(Constants.Time)]
        public DateTime Time { get; set; }
    }
}
