using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Components.Base
{
    [Serializable]
    public class StructureComponent : RecordComponent
    {
        [XmlElement(ElementName = Constants.Links)]
        public List<Link> Links { get; set; }

        [XmlElement(ElementName = Constants.Attestations)]
        public List<AttestationInfo> Attestations { get; set; }
    }
}
