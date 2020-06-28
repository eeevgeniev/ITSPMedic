using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using Medic.EHR.RM.Base;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    public class Element : Item
    {
        [XmlElement(ElementName = Constants.Value)]
        public DataValue Value { get; set; }
    }
}