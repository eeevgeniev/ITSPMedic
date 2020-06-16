using Medic.EHR.Clinical.Base;
using Medic.EHR.Infrastructure;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    public class Cluster<T> : Item<T>
    {
        [XmlElement(ElementName = Constants.Parts)]
        public List<Item<T>> Parts { get; set; }
    }
}
