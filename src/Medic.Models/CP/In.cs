using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class In
    {
        private const string DateFormat = "yyyy-MM-dd";
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";

        private DateTime _sendDate;
        private DateTime _examinationDate;
        private DateTime _entryDate;

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

        [XmlElement(ElementName = "SendAPr")]
        public string SendApr { get; set; }

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

        [XmlElement(ElementName = "plannedNo")]
        public int PlannedNumber { get; set; }

        [XmlElement(ElementName = "diagnose")]
        public List<Diagnose> Diagnoses { get; set; }

        [XmlElement(ElementName = "urgency")]
        public int Urgency { get; set; }

        [XmlElement(ElementName = "InAPr")]
        public string InApr { get; set; }

        [XmlElement(ElementName = "clinicalPath")]
        public string ClinicalPath { get; set; }

        [XmlElement(ElementName = "NZOKPay")]
        public int NZOKPay { get; set; }

        [XmlElement(ElementName = "inMedicalWard")]
        public decimal InMedicalWard { get; set; }

        [XmlIgnore]
        public DateTime EntryDate
        {
            get { return _entryDate; }
            set { _entryDate = value; }
        }

        [XmlElement(ElementName = "entryDate")]
        public string EntryDateAsString
        {
            get
            {
                if (_entryDate == default)
                {
                    return string.Empty;
                }

                return _entryDate.ToString(DateTimeFormat);
            }
            set
            {
                _entryDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "severity")]
        public int Severity { get; set; }

        [XmlElement(ElementName = "delay")]
        public int Delay { get; set; }

        [XmlElement(ElementName = "payer")]
        public int Payer { get; set; }

        [XmlElement(ElementName = "ageInDays")]
        public int AgeInDays { get; set;  }

        [XmlElement(ElementName = "weightInGrams")]
        public int WeightInGrams { get; set; }

        [XmlElement(ElementName = "birthWeight")]
        public int BirthWeight { get; set; }

        [XmlElement(ElementName = "motherIZYear")]
        public int MotherIZYear { get; set; }

        [XmlElement(ElementName = "motherIZNo")]
        public int MotherIZNo { get; set; }

        [XmlElement(ElementName = "IZYear")]
        public int IZYear { get; set; }

        [XmlElement(ElementName = "IZNo")]
        public int IZNo { get; set; }
    }
}