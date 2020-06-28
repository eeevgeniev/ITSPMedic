using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class ED : DataValue
    {
        [XmlElement(ElementName = Constants.MediaType)]
        public CS MediaType { get; set; }

        [XmlElement(ElementName = Constants.Charset)]
        public CS Charset { get; set; }

        [XmlElement(ElementName = Constants.Language)]
        public CS Language { get; set; }

        [XmlElement(ElementName = Constants.Size)]
        public int? Size { get; set; }

        [XmlElement(ElementName = Constants.Compression)]
        public CS Compression { get; set; }

        [XmlElement(ElementName = Constants.Reference)]
        public URI Reference { get; set; }

        [XmlElement(ElementName = Constants.IntegrityCheck)]
        public string IntegrityCheck { get; set; }

        [XmlElement(ElementName = Constants.IntegrityCheckAlgorithm)]
        public CS IntegrityCheckAlgorithm { get; set; }

        [XmlElement(ElementName = Constants.Thumbnail)]
        public ED Thumbnail { get; set; }

        [XmlElement(ElementName = Constants.Data)]
        public string Data { get; set; }

        [XmlElement(ElementName = Constants.AlternateString)]
        public SimpleText AlternateString { get; set; }
    }
}
