using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class URI : DataValue
    {
        [XmlElement(ElementName = Constants.Value)]
        public string Value { get; set; }

        [XmlElement(ElementName = Constants.Scheme)]
        public string Scheme { get; set; }

        [XmlElement(ElementName = Constants.Path)]
        public string Path { get; set; }

        [XmlElement(ElementName = Constants.FragmentId)]
        public string FragmentId { get; set; }

        [XmlElement(ElementName = Constants.UriQuery)]
        public string UriQuery { get; set; }

        [XmlElement(ElementName = Constants.Literal)]
        public string Literal { get; set; }
    }
}
