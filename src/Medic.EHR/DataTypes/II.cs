using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class II : DataValue
    {
        [XmlElement(ElementName = Constants.Extension)]
        public string Extension { get; set; }

        [XmlElement(ElementName = Constants.AssigningAuthorityName)]
        public string AssigningAuthorityName { get; set; }

        [XmlElement(ElementName = Constants.ValidTime)]
        public IVLTS ValidTime { get; set; }

        [XmlElement(ElementName = Constants.Root)]
        public OID Root { get; set; }
    }
}
