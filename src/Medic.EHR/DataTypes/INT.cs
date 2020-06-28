using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class INT : DataValue
    {
        [XmlElement(ElementName = Constants.Value)]
        public int Value { get; set; }
    }
}
