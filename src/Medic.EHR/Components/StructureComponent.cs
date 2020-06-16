using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class StructureComponent<T> : RecordComponent<T>
    {
        [XmlElement(ElementName = "links")]
        public List<Link<T>> Links { get; set; }

        [XmlElement(ElementName = "attestations")]
        public List<AttestationInfo<T>> Attestations { get; set; }
    }
}
