using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class VSD
    {
        [XmlElement(ElementName = "imeVSD")]
        public string NameVSD { get; set; }

        [XmlElement(ElementName = "kodVSD")]
        public string CodeVSD { get; set; }

        [XmlElement(ElementName = "ACHIcode")]
        public string ACHIcode { get; set; }
    }
}
