using Medic.EHR.Infrastructure;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class OID
    {
        [XmlElement(ElementName = Constants.Oid)]
        public string Oid { get; set; }
    }
}
