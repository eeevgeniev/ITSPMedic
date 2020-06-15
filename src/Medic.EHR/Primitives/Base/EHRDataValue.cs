using System.Xml.Serialization;

namespace Medic.EHR.Primitives.Base
{
    public abstract class EHRDataValue<T>
    {
        [XmlElement(ElementName = "value")]
        public T Value { get; set; }
    }
}
