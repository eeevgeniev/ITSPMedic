using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Implant
    {
        private const string DateFormat = "yyyy-MM-dd";

        private DateTime _date;
        private DateTime _distributorInvoiceDate;

        [XmlElement(ElementName = "productType")]
        public int ProductType { get; set; }

        [XmlElement(ElementName = "tradeName")]
        public string TradeName { get; set; }

        [XmlElement(ElementName = "ReferenceNo")]
        public string ReferenceNumber { get; set; }

        [XmlElement(ElementName = "manufacturer")]
        public string Manufacturer { get; set; }

        [XmlElement(ElementName = "id_provider")]
        public int ProviderId { get; set; }

        [XmlElement(ElementName = "provider")]
        public string Provider { get; set; }

        [XmlElement(ElementName = "code")]
        public string Code { get; set; }

        [XmlIgnore]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        [XmlElement(ElementName = "date")]
        public string DateAsString
        {
            get
            {
                if (_date == default)
                {
                    return string.Empty;
                }
                
                return _date.ToString(DateFormat);
            }

            set
            {
                _date = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "serialNumber")]
        public string SerialNumber { get; set; }

        [XmlElement(ElementName = "stickers")]
        public int Stickers { get; set; }

        [XmlElement(ElementName = "distributorInvoiceNo")]
        public string DistributorInvoiceNumber { get; set; }

        [XmlIgnore]
        public DateTime DistributorInvoiceDate
        {
            get { return _distributorInvoiceDate; }
            set { _distributorInvoiceDate = value; }
        }

        [XmlElement(ElementName = "distributorInvoiceDate")]
        public string DistributorInvoiceDateAsString
        {
            get
            {
                if (_distributorInvoiceDate == default)
                {
                    return string.Empty;
                }

                return _distributorInvoiceDate.ToString(DateFormat);
            }

            set
            {
                _distributorInvoiceDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "nhifAmount")]
        public decimal NhifAmount { get; set; }

        [XmlElement(ElementName = "patientAmount")]
        public decimal PatientAmount { get; set; }

        [XmlElement(ElementName = "totalAmount")]
        public decimal TotalAmount { get; set; }
    }
}
