using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Out
    {
        private const string DateFormat = "yyyy-MM-dd";
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";

        private DateTime _sendDate;
        private DateTime _examinationDate;
        private DateTime _entryDate;
        private DateTime _outDate;
        private DateTime? _hLDateFrom;
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
        public List<SendDiagnose> SendDiagnoses { get; set; }

        [XmlElement(ElementName = "sendUrgency")]
        public int SendUrgency { get; set; }

        [XmlElement(ElementName = "sendPackageType")]
        public int? SendPackageType { get; set; }

        [XmlElement(ElementName = "sendClinicalPath")]
        public double SendClinicalPath { get; set; }

        [XmlElement(ElementName = "sendAPr")]
        public int? SendAPr { get; set; }

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
        public List<Diagnose> Diagnoses { get; set; }

        [XmlElement(ElementName = "urgency")]
        public int Urgency { get; set; }

        [XmlElement(ElementName = "packageType")]
        public int? PackageType { get; set; }

        [XmlElement(ElementName = "clinicalPath")]
        public double ClinicalPath { get; set; }

        [XmlElement(ElementName = "InAPr")]
        public int? InAPr { get; set; }

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
        public int Delay { get; set; }

        [XmlElement(ElementName = "payer")]
        public int Payer { get; set; }

        [XmlElement(ElementName = "ageInDays")]
        public int? AgeInDays { get; set; }

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

        [XmlElement(ElementName = "outMedicalWard")]
        public decimal OutMedicalWard { get; set; }

        [XmlElement(ElementName = "outUin")]
        public string OutUniqueIdentifier { get; set; }

        [XmlIgnore]
        public DateTime OutDate
        {
            get { return _outDate; }
            set { _outDate = value; }
        }

        [XmlElement(ElementName = "outDate")]
        public string OutDateAsString
        {
            get
            {
                return _outDate == default ? default : _outDate.ToString(DateTimeFormat);
            }
            set
            {
                _outDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "outType")]
        public int OutType { get; set; }

        [XmlElement(ElementName = "dead")]
        public Dead Dead { get; set; }

        [XmlElement(ElementName = "BirthPractice")]
        public string BirthPractice { get; set; }

        [XmlElement(ElementName = "BirthNum")]
        public int? BirthNumber { get; set; }

        [XmlElement(ElementName = "BirthGestWeek")]
        public int? BirthGestWeek { get; set; }

        [XmlElement(ElementName = "resign")]
        public Resign Resign { get; set; }

        [XmlElement(ElementName = "Redirected")]
        public Redirected Redirected { get; set; }

        [XmlElement(ElementName = "outClinicalPath")]
        public double OutClinicalPath { get; set; }

        [XmlElement(ElementName = "outAPr")]
        public string OutAPr { get; set; }

        [XmlElement(ElementName = "histologicalResult")]
        public HistologicalResult HistologicalResult { get; set; }

        [XmlElement(ElementName = "epicrisis")]
        public Epicrisis Epicrisis { get; set; }

        [XmlElement(ElementName = "IZinDetail")]
        public string IZinDetail { get; set; }

        [XmlElement(ElementName = "outMainDiag")]
        public OutMainDiagnose OutMainDiagnose { get; set; }

        [XmlElement(ElementName = "outDiags")]
        public List<OutDiagnose> OutDiagnoses { get; set; }

        [XmlElement(ElementName = "Link_Media")]
        public string LinkMedia { get; set; }

        [XmlElement(ElementName = "UsedDrug")]
        public List<UsedDrug> UsedDrugs { get; set; }

        [XmlElement(ElementName = "Procedures")]
        public List<Procedure> Procedures { get; set; }

        [XmlElement(ElementName = "bedDays")]
        public int? BedDays { get; set; }

        [XmlIgnore]
        public DateTime? HLDateFrom
        {
            get { return _hLDateFrom; }
            set { _hLDateFrom = value; }
        }

        [XmlElement(ElementName = "HLDateFrom")]
        public string HLDateFromAsString
        {
            get
            {
                return _hLDateFrom == default ? default : ((DateTime)_hLDateFrom).ToString(DateFormat);
            }
            set
            {
                _hLDateFrom = DateTime.ParseExact(value, DateFormat, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "HLNo")]
        public string HLNumber { get; set; }

        [XmlElement(ElementName = "HLTotalDays")]
        public int? HLTotalDays { get; set; }

        [XmlElement(ElementName = "stateAtDischarge")]
        public int? StateAtDischarge { get; set; }

        [XmlElement(ElementName = "Laparoscopic")]
        public int? Laparoscopic { get; set; }


        [XmlElement(ElementName = "Pathologic_Finding")]
        public int? PathologicFinding { get; set; }

        [XmlElement(ElementName = "EndCourse")]
        public int? EndCourse { get; set; }
    }
}