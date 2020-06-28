using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class BL : DataValue
    {
        [XmlElement(ElementName = Constants.Value)]
        public bool Value { get; set; }
    }
}
