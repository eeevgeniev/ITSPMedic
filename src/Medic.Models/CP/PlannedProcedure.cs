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

        public Patient Patient { get; set; }

        [XmlElement(ElementName = "patientBranch")]
        public string PatientBranch { get; set; }

        [XmlElement(ElementName = "patientHRegion")]
        public string PatientHRegion { get; set; }

        [XmlElement(ElementName = "inType")]
        public int InType { get; set; }

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
                if (_sendDate == default)
                {
                    return string.Empty;
                }

                return _sendDate.ToString(DateFormat);
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
        public string SendClinicalPath { get; set; }

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
                if (_examinationDate == default)
                {
                    return string.Empty;
                }

                return _examinationDate.ToString(DateFormat);
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
                if (_plannedEntryDate == default)
                {
                    return string.Empty;
                }

                return _plannedEntryDate.ToString(DateFormat);
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
        public string ClinicalPath { get; set; }

        [XmlElement(ElementName = "NZOKPay")]
        public int NZOKPay { get; set; }
    }
}
