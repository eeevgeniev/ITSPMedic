using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class PlannedProcedure
    {
        private const string DateFormat = "yyyy-MM-dd";

        private DateTime _sendDate;
        private DateTime _examinationDate;
        private DateTime _plannedEntryDate;

        [XmlElement(ElementName = "Patient")]
        public Patient Patient { get; set; }

        [XmlElement(ElementName = "patientBranch")]
        public int? PatientBranch { get; set; }

        [XmlElement(ElementName = "patientHRegion")]
        public int? PatientHRegion { get; set; }

        [XmlElement(ElementName = "inType")]
        public int InType { get; set; }

        [XmlElement(ElementName = "Sender")]
        public Sender Sender { get; set; }

        [XmlIgnore]
        public DateTime SendDate
        {
            get { return _sendDate; }
            set { _sendDate = value; }
        }

        [XmlElement(ElementName = "sendDate")]
        public string SendDateAsString
        {
            get
            {
                return _sendDate == default ? default : _sendDate.ToString(DateFormat);
            }
            set
            {
                _sendDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "sendDiagnose")]
        public SendDiagnose SendDiagnose { get; set; }

        [XmlElement(ElementName = "sendUrgency")]
        public int SendUrgency { get; set; }

        [XmlElement(ElementName = "sendClinicalPath")]
        public double? SendClinicalPath { get; set; }

        [XmlElement(ElementName = "uin")]
        public string UniqueIdentifier { get; set; }

        [XmlIgnore]
        public DateTime ExaminationDate
        {
            get { return _examinationDate; }
            set { _examinationDate = value; }
        }

        [XmlElement(ElementName = "examinationDate")]
        public string ExaminationDateAsString
        {
            get
            {
                return _examinationDate == default ? default : _examinationDate.ToString(DateFormat);
            }
            set
            {
                _examinationDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlIgnore]
        public DateTime PlannedEntryDate
        {
            get { return _plannedEntryDate; }
            set { _plannedEntryDate = value; }
        }

        [XmlElement(ElementName = "plannedEntryDate")]
        public string PlannedEntryDateAsString
        {
            get
            {
                return _plannedEntryDate == default ? default : _plannedEntryDate.ToString(DateFormat);
            }
            set
            {
                _plannedEntryDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "plannedNo")]
        public int PlannedNumber { get; set; }

        [XmlElement(ElementName = "diagnose")]
        public Diagnose Diagnose { get; set; }

        [XmlElement(ElementName = "urgency")]
        public int Urgency { get; set; }

        [XmlElement(ElementName = "clinicalPath")]
        public double? ClinicalPath { get; set; }

        [XmlElement(ElementName = "NZOKPay")]
        public int NZOKPay { get; set; }
    }
}
