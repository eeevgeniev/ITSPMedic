using Medic.EHR.Primitives.Base;
using System.Xml.Serialization;

namespace Medic.EHR.Complexes
{
    public class CodedValue<T> : EHRDataValue<T>
    {
        [XmlElement(ElementName = "original_text")]
        public SimpleText OriginalText { get; set; }

        [XmlElement(ElementName = "code")]
        public string Code { get; set; }

        [XmlElement(ElementName = "code_system")]
        public string CodeSystem { get; set; }

        [XmlElement(ElementName = "display_name")]
        public string DisplayName { get; set; }
    }
}
