using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    [Serializable]
    public class RelatedParty
    {
        [XmlElement(ElementName = Constants.Party)]
        [JsonProperty(Constants.Party)]
        public II Party { get; set; }

        [XmlElement(ElementName = Constants.Relationship)]
        [JsonProperty(Constants.Relationship)]
        public Text Relationship { get; set; }
    }
}
