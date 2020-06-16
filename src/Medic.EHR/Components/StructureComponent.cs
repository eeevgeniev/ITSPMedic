using Medic.EHR.Infrastructure;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class StructureComponent<T> : RecordComponent<T>
    {
        [XmlElement(ElementName = Constants.Links)]
        public List<Link<T>> Links { get; set; }

        [XmlElement(ElementName = Constants.Attestations)]
        public List<AttestationInfo<T>> Attestations { get; set; }
    }
}
