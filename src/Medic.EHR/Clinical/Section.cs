using Medic.EHR.Clinical.Base;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    public class Section<T> : Content<T>
    {
        [XmlElement(ElementName = "members")]
        public List<Content<T>> Members { get; set; }
    }
}
