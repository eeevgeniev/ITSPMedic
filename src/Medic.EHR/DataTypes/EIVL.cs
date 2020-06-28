using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class EIVL : DataValue
    {
        [XmlElement(ElementName = Constants.Event)]
        public CD Event { get; set; }

        [XmlElement(ElementName = Constants.Offset)]
        public Duration Offset { get; set; }
    }
}
