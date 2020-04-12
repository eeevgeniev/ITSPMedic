using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class PredMarker
    {
        [XmlElement(ElementName = "Choises")]
        public List<Choise> Choises { get; set; }
    }
}
