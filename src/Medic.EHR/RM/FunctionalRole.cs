using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    public class FunctionalRole
    {
        [XmlElement(ElementName = Constants.Function)]
        public CV Function { get; set; }

        [XmlElement(ElementName = Constants.Performer)]
        public II Performer { get; set; }

        [XmlElement(ElementName = Constants.Mode)]
        public CS Mode { get; set; }

        [XmlElement(ElementName = Constants.HealthcareFacillity)]
        public II HealthcareFacillity { get; set; }

        [XmlElement(ElementName = Constants.ServiceSetting)]
        public CV ServiceSetting { get; set; }
    }
}
