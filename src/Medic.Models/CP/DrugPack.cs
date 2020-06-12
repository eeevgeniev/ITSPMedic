using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class DrugPack
    {
        private const string DateExpireFormat = "ddMMyy";

        private DateTime? _drugDate;
        private string _expireDateAsString;

        [XmlIgnore]
        public DateTime? DrugDate
        {
            get { return _drugDate;  }
            set { _drugDate = value; }
        }

        [XmlElement(ElementName = "Drug_Date")]
        public string DrugDateAsString
        {
            get
            {
                return _drugDate == default ? default : ((DateTime)_drugDate).ToString("yyyy-MM-dd");
            }
            set
            {
                _drugDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "Drug_Code")]
        public string DrugCode { get; set; }

        [XmlElement(ElementName = "Drug_Quantity")]
        public decimal? DrugQuantity { get; set; }

        [XmlElement(ElementName = "Batch_number")]
        public string BatchNumber { get; set; }

        [XmlElement(ElementName = "Product_code")]
        public string ProductCode { get; set; }

        [XmlElement(ElementName = "Expiry_date")]
        public string ExpireDateAsString 
        { 
            get
            {
                return _expireDateAsString;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.Length == 4)
                    {
                        _expireDateAsString = $"{value}00";
                    }

                    _expireDateAsString = value;
                }
            }
        }

        [XmlElement(ElementName = "Serial_number")]
        public string SerialNumber { get; set; }
    }
}
