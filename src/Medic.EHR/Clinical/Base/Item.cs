using Medic.EHR.Complexes;
using Medic.EHR.Components;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical.Base
{
    public abstract class Item<T> : StructureComponent<T>
    {
        [XmlElement(ElementName = Constants.Emphasis)]
        public CodedValue<T> Emphasis { get; set; }
    }
}