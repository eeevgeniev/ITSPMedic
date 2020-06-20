using Medic.EHR.Complexes;
using Medic.EHR.Components.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Components.Base
{
    [Serializable]
    public class RecordComponent : BaseComponent
    {
        [XmlElement(ElementName = Constants.ArchetypeId)]
        public InstanceIdentifier ArchetypeId { get; set; }
    }
}
