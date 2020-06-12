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
        private DateTime? _plannedEntryDate;

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
        public List<SendDiagnose> SendDiagnoses { get; set; }

        [XmlElement(ElementName = "sendUrgency")]
        public int SendUrgency { get; set; }

        [XmlElement(ElementName = "sendPackageType")]
        public int? SendPackageType { get; set; }

        [XmlElement(ElementName = "sendAPr")]
        public int? SendApr { get; set; }

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
                return _examinationDate == default ? default : _examinationDate.ToString(DateFormat);
            }
            set
            {
                _examinationDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlIgnore]
        public DateTime? PlannedEntryDate
        {
            get { return _plannedEntryDate; }
            set { _plannedEntryDate = value; }
        }

        [XmlElement(ElementName = "plannedEntryDate")]
        public string PlannedEntryDateAsString
        {
            get
            {
                return _plannedEntryDate == default ? default : ((DateTime)_plannedEntryDate).ToString(DateFormat);
            }
            set
            {
                _plannedEntryDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "plannedNo")]
        public int PlannedNumber { get; set; }

        [XmlElement(ElementName = "diagnose")]
        public List<Diagnose> Diagnoses { get; set; }

        [XmlElement(ElementName = "urgency")]
        public int Urgency { get; set; }

        [XmlElement(ElementName = "packageType")]
        public int? PackageType { get; set; }

        [XmlElement(ElementName = "InAPr")]
        public int? InApr { get; set; }

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
                return _entryDate == default ? default : _entryDate.ToString(DateTimeFormat);
            }
            set
            {
                _entryDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "severity")]
        public int Severity { get; set; }

        [XmlElement(ElementName = "delay")]
        public int? Delay { get; set; }

        [XmlElement(ElementName = "payer")]
        public int Payer { get; set; }

        [XmlElement(ElementName = "ageInDays")]
        public int? AgeInDays { get; set;  }

        [XmlElement(ElementName = "weightInGrams")]
        public int? WeightInGrams { get; set; }

        [XmlElement(ElementName = "birthWeight")]
        public int? BirthWeight { get; set; }

        [XmlElement(ElementName = "motherIZYear")]
        public int? MotherIZYear { get; set; }

        [XmlElement(ElementName = "motherIZNo")]
        public int? MotherIZNo { get; set; }

        [XmlElement(ElementName = "IZYear")]
        public int? IZYear { get; set; }

        [XmlElement(ElementName = "IZNo")]
        public int? IZNo { get; set; }
    }
}