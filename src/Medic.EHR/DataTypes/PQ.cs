using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class PQ : Quantity
    {
        [XmlElement(ElementName = Constants.Value)]
        public double Value { get; set; }

        [XmlElement(ElementName = Constants.Units)]
        public CS Units { get; set; }

        [XmlElement(ElementName = Constants.Property)]
        public CD Property { get; set; }

        [XmlElement(ElementName = Constants.Precision)]
        public int? Precision { get; set; }
    }
}
