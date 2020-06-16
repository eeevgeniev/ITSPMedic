using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives;
using System.Xml.Serialization;

namespace Medic.EHR.Complexes
{
    public class Attachment : EHRString
    {
        [XmlElement(ElementName = Constants.Description)]
        public SimpleText Description { get; set; }

        [XmlElement(ElementName = Constants.MediaType)]
        public CodedSimple MediaType { get; set; }

        [XmlElement(ElementName = Constants.Reference)]
        public URI Reference { get; set; }

        [XmlElement(ElementName = Constants.IntegrityCheckAlgorithm)]
        public CodedSimple IntegrityCheckAlgorithm { get; set; }

        [XmlElement(ElementName = Constants.Thumbnail)]
        public Attachment Thumbnail { get; set; }

        [XmlElement(ElementName = Constants.IntegrityCheck)]
        public string IntegrityCheck { get; set; }
    }
}
