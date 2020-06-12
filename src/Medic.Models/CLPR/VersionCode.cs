using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class VersionCode
    {
        private DateTime? _expireDate;

        [XmlElement(ElementName = "Batch_number")]
        public string BatchNumber { get; set; }

        [XmlElement(ElementName = "Product_code")]
        public string ProductCode { get; set; }

        [XmlIgnore]
        public DateTime? ExpireDate
        {
            get { return _expireDate; }
            set { _expireDate = value; }
        }

        [XmlElement(ElementName = "Expiry_date")]
        public string ExpireDateAsString
        {
            get
            {
                return _expireDate == default ? default : ((DateTime)_expireDate).ToString("YYMMDD");
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _expireDate = DateTime.ParseExact(value, "YYMMDD", CultureInfo.InvariantCulture);
                }
            }
        }

        [XmlElement(ElementName = "Serial_number")]
        public string SerialNumber { get; set; }

        [XmlElement(ElementName = "DataMatrix")]
        public string DataMatrix { get; set; }

        [XmlElement(ElementName = "quantity_pack")]
        public decimal QuantityPack { get; set; }
    }
}