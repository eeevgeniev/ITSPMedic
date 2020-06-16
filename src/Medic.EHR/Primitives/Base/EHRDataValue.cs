using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.Primitives.Base
{
    public abstract class EHRDataValue<T>
    {
        [XmlAttribute(AttributeName = Constants.Value)]
        public T Value { get; set; }
    }
}
