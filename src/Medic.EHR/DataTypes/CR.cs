using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class CR
    {
        [XmlElement(ElementName = Constants.Inverted)]
        public bool? Inverted { get; set; } 

        [XmlElement(ElementName = Constants.QualCode)]
        public CV QualCode { get; set; }

        [XmlElement(ElementName = Constants.Role)]
        public CV Role { get; set; }
    }
}
