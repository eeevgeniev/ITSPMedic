using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes.Base
{
    [Serializable]
    public abstract class DataValue
    {
        [XmlElement(ElementName = Constants.NullFlavor)]
        [JsonProperty(Constants.NullFlavor)]
        public CS NullFlavor { get; set; }
    }
}
