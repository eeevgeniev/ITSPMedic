using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives.Base;
using System.Xml.Serialization;

namespace Medic.EHR.Complexes
{
    public class CodedValue<T> : EHRDataValue<T>
    {
        [XmlElement(ElementName = "original_text")]
        public SimpleText OriginalText { get; set; }

        [XmlAttribute(AttributeName = Constants.Code)]
        public string Code { get; set; }

        [XmlAttribute(AttributeName = Constants.CodeSystem)]
        public string CodeSystem { get; set; }

        [XmlAttribute(AttributeName = Constants.DisplayName)]
        public string DisplayName { get; set; }
    }
}
