using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class HematologyPart
    {
        [XmlElement(ElementName = "Pred_Marker")]
        public PredMarker PredMarker { get; set; }
    }
}
