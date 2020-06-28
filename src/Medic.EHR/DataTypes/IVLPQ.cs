using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class IVLPQ : DataValue
    {
        [XmlElement(ElementName = Constants.Low)]
        public PQ Low { get; set; }

        [XmlElement(ElementName = Constants.High)]
        public PQ High { get; set; }

        [XmlElement(ElementName = Constants.LowClosed)]
        public bool? LowClosed { get; set; }

        [XmlElement(ElementName = Constants.HighClosed)]
        public bool? HighClosed { get; set; }

        [XmlElement(ElementName = Constants.Width)]
        public PQ Width { get; set; }
    }
}
