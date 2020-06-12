using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class DrugResidue
    {
        private const string DateFormat = "yyyy-MM-dd";

        private DateTime? _drugDate;
        private DateTime? _expiryDate;

        [XmlIgnore]
        public DateTime? DrugDate
        {
            get { return _drugDate; }
            set { _drugDate = value; }
        }

        [XmlElement(ElementName = "Drug_Date")]
        public string DrugDateAsString
        {
            get
            {
                return _drugDate == default ? default : ((DateTime)_drugDate).ToString(DateFormat);
            }
            set
            {
                _drugDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "Drug_Code")]
        public string DrugCode { get; set; }

        [XmlElement(ElementName = "Drug_Quantity")]
        public decimal? Quantity { get; set; }

        [XmlElement(ElementName = "Drug_Cost")]
        public decimal? DrugCost { get; set; }

        [XmlElement(ElementName = "Product_code")]
        public string ProductCode { get; set; }

        [XmlIgnore]
        public DateTime? ExpiryDate
        {
            get { return _expiryDate; }
            set { _expiryDate = value; }
        }

        [XmlElement(ElementName = "Expiry_date")]
        public string ExpiryDateAsString
        {
            get
            {
                return _expiryDate == default ? default : ((DateTime)_expiryDate).ToString(DateFormat);
            }
            set
            {
                _expiryDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "Batch_number")]
        public string BatchNumber { get; set; }

        [XmlElement(ElementName = "Serial_number")]
        public string SerialNumber { get; set; }
    }
}
