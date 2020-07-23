using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class CE : CV
    {
        [XmlElement(ElementName = Constants.Mappings)]
        [JsonProperty(Constants.Mappings)]
        public List<CD> Mappings { get; set; }
    }
}
