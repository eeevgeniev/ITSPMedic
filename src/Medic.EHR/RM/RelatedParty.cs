using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    public class RelatedParty
    {
        [XmlElement(ElementName = Constants.Party)]
        public II Party { get; set; }

        [XmlElement(ElementName = Constants.Relationship)]
        public Text Relationship { get; set; }
    }
}
