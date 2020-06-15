using Medic.EHR.Primitives.Base;
using System.Xml.Serialization;

namespace Medic.EHR.Complexes
{
    public class InstanceIdentifier<T> : EHRDataValue<T>
    {
        [XmlElement(ElementName = "root")]
        public string Root { get; set; }

        [XmlElement(ElementName = "extension")]
        public string Extension { get; set; }

        [XmlElement(ElementName = "identifier_name")]
        public string IdentifierName { get; set; }
    }
}
