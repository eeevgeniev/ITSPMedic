using Medic.EHR.Complexes;
using Medic.EHR.Components.Base;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class RecordComponent<T> : BaseComponent<T>
    {
        [XmlElement(ElementName = "archetype_id")]
        public InstanceIdentifier<T> ArchetypeId { get; set; }
    }
}
