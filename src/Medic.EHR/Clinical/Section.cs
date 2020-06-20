using Medic.EHR.Clinical.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    [Serializable]
    public class Section : Content
    {
        [XmlElement(ElementName = Constants.Members)]
        public List<Content> Members { get; set; }
    }
}
