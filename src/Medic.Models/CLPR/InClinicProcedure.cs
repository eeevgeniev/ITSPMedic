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
        private DateTime _firstVisitDate;
        private DateTime _planVisitDate;

        [XmlElement(ElementName = "Patient")]
        public Patient Patient { get; set; }

        [XmlElement(ElementName = "patientBranch")]
        public string PatientBranch { get; set; }

        [XmlElement(ElementName = "patientHRegion")]
        public string PatientHRegion { get; set; }

        [XmlElement(ElementName = "Sender")]
        public Sender Sender { get; set; }

        [XmlElement(ElementName = "CPr_Send")]
        public string CPrSend { get; set; }

        [XmlElement(ElementName = "APr_Send")]
        public string APrSend { get; set; }

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
                if (_dateSend == default)
                {
                    return string.Empty;
                }
                
                return _dateSend.ToString(DateFormat);
            }
            set
            {
                _dateSend = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "CPr_Priem")]
        public string CPrPriem { get; set; }

        [XmlElement(ElementName = "APr_Priem")]
        public string APrPriem { get; set; }

        [XmlElement(ElementName = "TypeProc_Priem")]
        public int TypeProcPriem { get; set; }

        [XmlElement(ElementName = "Proc_Refuse")]
        public int ProcRefuse { get; set; }

        [XmlElement(ElementName = "ceasedClinicalPath")]
        public CeasedClinicalPath CeasedClinicalPath { get; set; }

        [XmlElement(ElementName = "IZNum_Child")]
        public string IZNumChild { get; set; }

        [XmlElement(ElementName = "IZYear_Child")]
        public int IZYearChild { get; set; }

        [XmlIgnore]
        public DateTime FirstVisitDate
        {
            get { return _firstVisitDate; }
            set { _firstVisitDate = value; }
        }

        [XmlElement(ElementName = "Date_FirstVisit")]
        public string FirstVisitDateAsString
        {
            get
            {
                if (_firstVisitDate == default)
                {
                    return string.Empty;
                }

                return _firstVisitDate.ToString(DateFormat);
            }
            set
            {
                _firstVisitDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlIgnore]
        public DateTime PlanVisitDate
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
                    return string.Empty;
                }

                return _planVisitDate.ToString(DateFormat);
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
        public int PacientStatus { get; set; }

        [XmlElement(ElementName = "NZOKPay")]
        public int NZOKPay { get; set; }
    }
}