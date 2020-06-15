using Medic.EHR.Primitives;
using System.Xml.Serialization;

namespace Medic.EHR.Complexes
{
    public class Attachment : EHRString
    {
        [XmlElement(ElementName = "description")]
        public SimpleText Description { get; set; }

        [XmlElement(ElementName = "media_type")]
        public CodedSimple MediaType { get; set; }

        [XmlElement(ElementName = "reference")]
        public URI Reference { get; set; }

        [XmlElement(ElementName = "integrity_check_algorithm")]
        public CodedSimple IntegrityCheckAlgoritm { get; set; }

        [XmlElement(ElementName = "thumbnail")]
        public Attachment Thumbnail { get; set; }

        [XmlElement(ElementName = "integrityCheck")]
        public string IntegrityCheck { get; set; }
    }
}
