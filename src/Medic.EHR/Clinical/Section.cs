using Medic.EHR.Clinical.Base;
using Medic.EHR.Infrastructure;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    public class Section<T> : Content<T>
    {
        [XmlElement(ElementName = Constants.Members)]
        public List<Content<T>> Members { get; set; }
    }
}
