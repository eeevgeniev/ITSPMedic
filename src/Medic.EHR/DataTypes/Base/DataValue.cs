using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes.Base
{
    public abstract class DataValue
    {
        [XmlElement(ElementName = Constants.NullFlavor)]
        public CS NullFlavor { get; set; }
    }
}
