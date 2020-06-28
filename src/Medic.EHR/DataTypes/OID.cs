using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class OID
    {
        [XmlElement(ElementName = Constants.Oid)]
        public string Oid { get; set; }
    }
}
