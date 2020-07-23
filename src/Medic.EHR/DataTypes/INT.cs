using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class INT : DataValue
    {
        [XmlElement(ElementName = Constants.Value)]
        [JsonProperty(Constants.Value)]
        public int Value { get; set; }
    }
}
