using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class CE : CV
    {
        [XmlElement(ElementName = Constants.Mappings)]
        public List<CD> Mappings { get; set; }
    }
}
