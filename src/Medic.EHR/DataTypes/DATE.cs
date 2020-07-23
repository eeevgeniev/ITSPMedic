using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class DATE : DataValue
    {
        [XmlElement(ElementName = Constants.Date)]
        [JsonProperty(Constants.Date)]
        public DateTime Date { get; set; }
    }
}
