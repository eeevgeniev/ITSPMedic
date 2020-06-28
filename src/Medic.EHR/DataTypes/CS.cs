using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class CS
    {
        [XmlElement(ElementName = Constants.CodingScheme)]
        public OID CodingScheme { get; set; }

        [XmlElement(ElementName = Constants.CodingSchemeName)]
        public string CodingSchemeName { get; set; }

        [XmlElement(ElementName = Constants.CodingSchemeVersion)]
        public string CodingSchemeVersion { get; set; }

        [XmlElement(ElementName = Constants.CodeValue)]
        public string CodeValue { get; set; }
    }
}
