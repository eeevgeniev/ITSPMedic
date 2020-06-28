using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class CV : CS
    {
        [XmlElement(ElementName = Constants.DisplayName)]
        public string DisplayName { get; set; }
    }
}
