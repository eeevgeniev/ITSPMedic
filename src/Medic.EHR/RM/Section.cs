﻿using Medic.EHR.Infrastructure;
using Medic.EHR.RM.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    [Serializable]
    public class Section : Content
    {
        [XmlElement(ElementName = Constants.Members)]
        [JsonProperty(Constants.Members)]
        public List<Content> Members { get; set; }
    }
}
