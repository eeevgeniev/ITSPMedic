using Medic.EHR.Clinical.Base;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    public class Cluster<T> : Item<T>
    {
        [XmlElement(ElementName = "parts")]
        public List<Item<T>> Parts { get; set; }
    }
}
