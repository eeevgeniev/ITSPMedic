using Medic.Models.CP;
using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class InClinicProcedure
    {
        private const string DateFormat = "yyyy-MM-dd";

        private DateTime _dateSend;
        private DateTime? _firstVisitDate;
        private DateTime? _planVisitDate;

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
        public double? APrSend { get; set; }

        [XmlElement(ElementName = "TypeProc_Send")]
        public decimal? TypeProcSend { get; set; }

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
        public double? APrPriem { get; set; }

        [XmlElement(ElementName = "TypeProc_Priem")]
        public int TypeProcPriem { get; set; }

        [XmlElement(ElementName = "Proc_Refuse")]
        public int ProcRefuse { get; set; }

        [XmlElement(ElementName = "ceasedClinicalPath")]
        public CeasedClinicalPath CeasedClinicalPath { get; set; }

        [XmlElement(ElementName = "IZNum_Child")]
        public int? IZNumChild { get; set; }

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
        public DateTime? PlanVisitDate
        {
            get { return _planVisitDate; }
            set { _planVisitDate = value; }
        }

        [XmlElement(ElementName = "Date_PlanPriem")]
        public string PlanVisitDateAsString
        {
            get
            {
                if (_planVisitDate == default)
                {
                    return default;
                }

                return ((DateTime)_planVisitDate).ToString(DateFormat);
            }
            set
            {
                _planVisitDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
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

        [XmlElement(ElementName = "pacientStatus")]
        public int PatientStatus { get; set; }

        [XmlElement(ElementName = "NZOKPay")]
        public int NZOKPay { get; set; }
    }
}