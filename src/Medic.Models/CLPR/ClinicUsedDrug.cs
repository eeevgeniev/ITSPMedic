using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class ClinicUsedDrug
    {
        private DateTime _drugDate;
        private DateTime _datePrescr;
        private DateTime _protocolDate;
        
        [XmlIgnore]
        public DateTime DrugDate
        {
            get { return _drugDate; }
            set { _drugDate = value; }
        }

        [XmlElement(ElementName = "Drug_Date")]
        public string DrugDateAsString
        {
            get 
            {
                return _drugDate == default ? default : _drugDate.ToString("yyyy-MM-dd");
            }
            set 
            {
                _drugDate = DateTime.Parse(value, CultureInfo.CurrentCulture);
            }
        }

        [XmlElement(ElementName = "Drug_Code")]
        public string DrugCode { get; set; }

        [XmlElement(ElementName = "Drug_Name")]
        public string DrugName { get; set; }

        [XmlElement(ElementName = "Drug_Quantity")]
        public decimal DrugQuantity { get; set; }

        [XmlElement(ElementName = "Drug_Cost")]
        public decimal DrugCost { get; set; }

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
                return _datePrescr == default ? string.Empty : _drugDate.ToString("yyyy-MM-dd");
            }
            set
            {
                _datePrescr = DateTime.Parse(value, CultureInfo.CurrentCulture);
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
                _protocolDate = DateTime.Parse(value, CultureInfo.CurrentCulture);
            }
        }

        [XmlElement(ElementName = "type_Protocol")]
        public int ProtocolType { get; set; }

        [XmlElement(ElementName = "Ver_Code")]
        public VersionCode VersionCode { get; set; }
    }
}