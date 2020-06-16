using Medic.EHR.Complexes;
using Medic.EHR.Components.Base;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class RecordComponent<T> : BaseComponent<T>
    {
        [XmlElement(ElementName = Constants.ArchetypeId)]
        public InstanceIdentifier<T> ArchetypeId { get; set; }
    }
}
