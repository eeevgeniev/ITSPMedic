using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class ExtractedComponentSet<T>
    {
        [XmlElement(ElementName = "structure_components")]
        public List<StructureComponent<T>> StructureComponents { get; set; }
    }
}