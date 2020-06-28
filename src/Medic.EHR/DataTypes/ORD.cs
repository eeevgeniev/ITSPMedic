using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class ORD : Quantity
    {
        [XmlElement(ElementName = Constants.Value)]
        public int Value { get; set; }

        [XmlElement(ElementName = Constants.Symbol)]
        public CodedText Symbol { get; set; }
    }
}
