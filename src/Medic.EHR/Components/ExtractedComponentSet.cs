using Medic.EHR.Infrastructure;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class ExtractedComponentSet<T>
    {
        [XmlElement(ElementName = Constants.StructureComponents)]
        public List<StructureComponent<T>> StructureComponents { get; set; }
    }
}