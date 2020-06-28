using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.RM.Base
{
    public abstract class Item : RecordComponent
    {
        [XmlElement(ElementName = Constants.Emphasis)]
        public CV Emphasis { get; set; }

        [XmlElement(ElementName = Constants.ObsTime)]
        public IVLTS ObsTime { get; set; }

        [XmlElement(ElementName = Constants.ItemCategory)]
        public CS ItemCategory { get; set; }
    }
}
