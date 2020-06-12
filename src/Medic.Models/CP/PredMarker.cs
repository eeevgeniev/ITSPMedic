using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class PredMarker
    {
        [XmlElement(ElementName = "Choise")]
        public List<Choice> Choices { get; set; }

        [XmlElement(ElementName = "Marker")]
        public List<Marker> Markers { get; set; }
    }
}
