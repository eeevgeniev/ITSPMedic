using Medic.Models.CLPR;
using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class UsedDrug
    {
        private DateTime _date;
        private DateTime _datePrescr;
        private DateTime _protocolDate;

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
                return _date == default ? string.Empty : _date.ToString("yyyy-MM-dd");
            }
            set
            {
                _date = DateTime.Parse(value, CultureInfo.CurrentCulture);
            }
        }

        [XmlElement(ElementName = "code")]
        public string Code { get; set; }

        [XmlElement(ElementName = "quantity")]
        public decimal Quantity { get; set; }

        [XmlElement(ElementName = "cost")]
        public decimal Cost { get; set; }

        [XmlElement(ElementName = "ICD_drug")]
        public string ICDDrug { get; set; }

        [XmlElement(ElementName = "UIN_prescr")]
        public string UINPrescr { get; set; }

        [XmlElement(ElementName = "No_prescr")]
        public string NoPrescr { get; set; }

        [XmlIgnore]
        public DateTime DatePrescr
        {
            get { return _datePrescr; }
            set { _datePrescr = value; }
        }

        [XmlElement(ElementName = "date_prescr")]
        public string DatePrescrAsString
        {
            get
            {
                return _datePrescr == default ? string.Empty : _date.ToString("yyyy-MM-dd");
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _datePrescr = DateTime.Parse(value, CultureInfo.CurrentCulture);
                }
            }
        }

        [XmlElement(ElementName = "PracticeCode_Protocol")]
        public string PracticeCodeProtocol { get; set; }

        [XmlElement(ElementName = "No_Protocol")]
        public int ProtocolNumber { get; set; }

        [XmlIgnore]
        public DateTime ProtocolDate
        {
            get { return _protocolDate; }
            set { _protocolDate = value; }
        }

        [XmlElement(ElementName = "date_Protocol")]
        public string ProtocolDateAsString
        {
            get
            {
                return _protocolDate == default ? string.Empty : _protocolDate.ToString("yyyy-MM-dd");
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _protocolDate = DateTime.Parse(value, CultureInfo.CurrentCulture);
                }
            }
        }

        [XmlElement(ElementName = "type_Protocol")]
        public int ProtocolType { get; set; }

        [XmlElement(ElementName = "Ver_Code")]
        public VersionCode VersionCode { get; set; }
    }
}
