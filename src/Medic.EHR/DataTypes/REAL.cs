using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class REAL : DataValue
    {
        [XmlElement(ElementName = Constants.Value)]
        public double Value { get; set; }
    }
}
