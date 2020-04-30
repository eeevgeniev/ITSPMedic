using Medic.Models.CP;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class PathProcedure
    {
        private const string DateFormat = "yyyy-MM-dd";

        private DateTime _dateSend;
        private DateTime? _firstVisitDate;
        private DateTime? _dateProcedureBegins;
        private DateTime? _datePlanPriem;
        private DateTime? _dateProcedureEnd;

        [XmlElement(ElementName = "Patient")]
        public Patient Patient { get; set; }

        [XmlElement(ElementName = "patientBranch")]
        public int? PatientBranch { get; set; }

        [XmlElement(ElementName = "patientHRegion")]
        public int? PatientHRegion { get; set; }

        [XmlElement(ElementName = "Sender")]
        public Sender Sender { get; set; }

        [XmlElement(ElementName = "CPr_Send")]
        public double? CPrSend { get; set; }

        [XmlElement(ElementName = "APr_Send")]
        public decimal? APrSend { get; set; }

        [XmlElement(ElementName = "TypeProc_Send")]
        public int TypeProcSend { get; set; }

        [XmlIgnore]
        public DateTime DateSend
        {
            get { return _dateSend; }
            set { _dateSend = value; }
        }

        [XmlElement(ElementName = "Date_Send")]
        public string DateSendAsString
        {
            get
            {
                return _dateSend == default ? default : _dateSend.ToString(DateFormat);
            }
            set
            {
                _dateSend = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "CPr_Priem")]
        public double? CPrPriem { get; set; }

        [XmlElement(ElementName = "APr_Priem")]
        public decimal? APrPriem { get; set; }

        public decimal MedicalWard { get; set; }

        [XmlElement(ElementName = "TypeProc_Priem")]
        public int TypeProcPriem { get; set; }

        [XmlElement(ElementName = "Proc_Refuse")]
        public int ProcRefuse { get; set; }

        [XmlElement(ElementName = "ceasedProc")]
        public CeasedClinicalPath CeasedProcedure { get; set; }

        [XmlElement(ElementName = "ceasedClinicalPath")]
        public CeasedClinicalPath CeasedClinicalPath { get; set; }

        [XmlElement(ElementName = "IZNum_Child")]
        public string IZNumChild { get; set; }

        [XmlElement(ElementName = "IZYear_Child")]
        public int IZYearChild { get; set; }

        [XmlIgnore]
        public DateTime? FirstVisitDate
        {
            get { return _firstVisitDate; }
            set { _firstVisitDate = value; }
        }

        [XmlElement(ElementName = "Date_FirstVisit")]
        public string FirstVisitDateAsString
        {
            get
            {
                return _firstVisitDate == default ? default : ((DateTime)_firstVisitDate).ToString(DateFormat);
            }
            set
            {
                _firstVisitDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlIgnore]
        public DateTime? DatePlanPriem
        {
            get { return _datePlanPriem; }
            set { _datePlanPriem = value; }
        }

        [XmlElement(ElementName = "Date_PlanPriem")]
        public string DatePlanPriemAsString
        {
            get
            {
                return _datePlanPriem == default ? default : ((DateTime)_datePlanPriem).ToString(DateFormat);
            }
            set
            {
                _datePlanPriem = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "UIN_PriemDoc")]
        public string VisitDocumentUniqueIdentifier { get; set; }

        [XmlElement(ElementName = "Name_PriemDoc")]
        public string VisitDocumentName { get; set; }

        [XmlElement(ElementName = "MainDiag1")]
        public Diag MainDiag1 { get; set; }

        [XmlElement(ElementName = "MainDiag2", IsNullable = false)]
        public Diag MainDiag2 { get; set; }

        [XmlIgnore]
        public DateTime? DateProcedureBegins
        {
            get { return _dateProcedureBegins; }
            set { _dateProcedureBegins = value; }
        }

        [XmlElement(ElementName = "Date_Proc_Begin")]
        public string DateProcedureBeginsAsString
        {
            get
            {
                return _dateProcedureBegins == default ? default : ((DateTime)_dateProcedureBegins).ToString(DateFormat);
            }
            set
            {
                _dateProcedureBegins = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlIgnore]
        public DateTime? DateProcedureEnd
        {
            get { return _dateProcedureEnd; }
            set { _dateProcedureEnd = value; }
        }

        [XmlElement(ElementName = "Date_Proc_End")]
        public string DateProcedureEndAsString
        {
            get
            {
                return _dateProcedureEnd == default ? default : ((DateTime)_dateProcedureEnd).ToString(DateFormat);
            }
            set
            {
                _dateProcedureEnd = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "Done_New_Proc")]
        public List<DoneNewProcedure> DoneNewProcedures { get; set; }

        [XmlElement(ElementName = "Used_Drug")]
        public ClinicUsedDrug UsedDrug { get; set; }

        [XmlElement(ElementName = "Procedure")]
        public List<ClinicProcedure> ClinicProcedures { get; set; }

        [XmlElement(ElementName = "Done_Proc")]
        public List<DoneProcedure> DoneProcedures { get; set; }

        [XmlElement(ElementName = "All_Done_Proc")]
        public decimal AllDoneProcedures { get; set; }

        [XmlElement(ElementName = "All_Done_Cost")]
        public decimal AllDoneCost { get; set; }

        [XmlElement(ElementName = "pacientStatus")]
        public int PatientStatus { get; set; }

        [XmlElement(ElementName = "outUin")]
        public string OutUniqueIdentifier { get; set; }

        [XmlElement(ElementName = "Sign")]
        public int Sign { get; set; }

        [XmlElement(ElementName = "NZOKPay")]
        public int NZOKPay { get; set; }
    }
}