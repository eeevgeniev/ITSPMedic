using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class VersionCode
    {
        [XmlElement(ElementName = "Batch_number")]
        public string BatchNumber { get; set; }

        [XmlElement(ElementName = "quantity_pack")]
        public decimal QuantityPack { get; set; }
    }
}