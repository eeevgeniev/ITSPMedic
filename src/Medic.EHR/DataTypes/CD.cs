using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class CD : CE
    {
        [XmlElement(ElementName = Constants.Qualifiers)]
        public List<CR> Qualifiers { get; set; }
    }
}
