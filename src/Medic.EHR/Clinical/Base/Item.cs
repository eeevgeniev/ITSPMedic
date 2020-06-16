using Medic.EHR.Complexes;
using Medic.EHR.Components;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical.Base
{
    public abstract class Item<T> : StructureComponent<T>
    {
        [XmlElement(ElementName = "emphasis")]
        public CodedValue<T> Emphasis { get; set; }
    }
}