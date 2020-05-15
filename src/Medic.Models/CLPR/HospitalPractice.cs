using Medic.Models.CP;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    [XmlRoot(ElementName = "HOSP_Practice")]
    public class HospitalPractice
    {
        private const string DateFormat = "yyyy-MM-dd";
        
        private DateTime _dateFrom;
        private DateTime _dateTo;

        [XmlElement(ElementName = "ZdrRajon")]
        public int? HealthRegion { get; set; }

        [XmlElement(ElementName = "PracticeCode")]
        public string PracticeCode { get; set; }

        [XmlElement(ElementName = "PracticeName")]
        public string PracticeName { get; set; }

        [XmlIgnore]
        public DateTime DateFrom
        {
            get { return _dateFrom; }
            set { _dateFrom = value; }
        }

        [XmlElement(ElementName = "DateFrom")]
        public string DateFromAsString
        {
            get
            {
                return _dateFrom == default ? default : _dateFrom.ToString(DateFormat);
            }
            set
            {
                _dateFrom = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlIgnore]
        public DateTime DateTo
        {
            get { return _dateTo; }
            set { _dateTo = value; }
        }

        [XmlElement(ElementName = "DateTo")]
        public string DateToAsString
        {
            get
            {
               return _dateTo == default ? default : _dateTo.ToString(DateFormat);
            }
            set
            {
                _dateTo = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "fileType")]
        public string FileType { get; set; }

        [XmlElement(ElementName = "In_Clin_Proc")]
        public List<InClinicProcedure> InClinicProcedures { get; set; }

        [XmlElement(ElementName = "Napr_Proc")]
        public List<PathProcedure> PathProcedures { get; set; }

        [XmlElement(ElementName = "Disp_Observ")]
        public List<DispObservation> DispObservations { get; set; }

        [XmlElement(ElementName = "APr_Commission")]
        public List<CommissionApr> CommissionAprs { get; set; }

        [XmlElement(ElementName = "Protocol_DrugTherapy")]
        public List<ProtocolDrugTherapy> ProtocolDrugTherapies { get; set; } 

        [XmlElement(ElementName = "PatientTransfers")]
        public PatientTransfer PatientTransfer { get; set; }
    }
}
