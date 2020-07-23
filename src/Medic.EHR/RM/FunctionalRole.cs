using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    [Serializable]
    public class FunctionalRole
    {
        [XmlElement(ElementName = Constants.Function)]
        [JsonProperty(Constants.Function)]
        public CV Function { get; set; }

        [XmlElement(ElementName = Constants.Performer)]
        [JsonProperty(Constants.Performer)]
        public II Performer { get; set; }

        [XmlElement(ElementName = Constants.Mode)]
        [JsonProperty(Constants.Mode)]
        public CS Mode { get; set; }

        [XmlElement(ElementName = Constants.HealthcareFacillity)]
        [JsonProperty(Constants.HealthcareFacillity)]
        public II HealthcareFacillity { get; set; }

        [XmlElement(ElementName = Constants.ServiceSetting)]
        [JsonProperty(Constants.ServiceSetting)]
        public CV ServiceSetting { get; set; }
    }
}
