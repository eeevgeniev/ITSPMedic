using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class Duration : Quantity
    {
        [XmlElement(ElementName = Constants.Days)]
        public int? Days { get; set; }

        [XmlElement(ElementName = Constants.Hours)]
        public int? Hours { get; set; }

        [XmlElement(ElementName = Constants.Minutes)]
        public int? Minutes { get; set; }

        [XmlElement(ElementName = Constants.Seconds)]
        public int? Seconds { get; set; }

        [XmlElement(ElementName = Constants.FractionalSecond)]
        public double? FractionalSecond { get; set; }

        [XmlElement(ElementName = Constants.Sign)]
        public int? Sign { get; set; }
    }
}
