using Medic.EHR.Clinical.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    [Serializable]
    public class Cluster : Item
    {
        [XmlElement(ElementName = Constants.Parts)]
        public List<Item> Parts { get; set; }
    }
}
