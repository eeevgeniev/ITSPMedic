using Medic.Models.CP;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class DispObservation
    {
        private const string DateFormat = "yyyy-MM-dd";
        
        private DateTime _dispDate;
        private DateTime _diagDate;
        private DateTime? _dispancerDate;
        
        [XmlElement(ElementName = "Patient")]
        public Patient Patient { get; set; }

        [XmlElement(ElementName = "patientBranch")]
        public int? PatientBranch { get; set; }

        [XmlElement(ElementName = "patientHRegion")]
        public int? PatientHRegion { get; set; }

        [XmlElement(ElementName = "Sender")]
        public Sender Sender { get; set; }

        [XmlElement(ElementName = "Doctor")]
        public Doctor Doctor { get; set; }

        [XmlElement(ElementName = "Disp_Num")]
        public int DispNum { get; set; }

        [XmlIgnore]
        public DateTime DispDate 
        { 
            get { return _dispDate;}
            set 
            { 
                if (_dispDate == default)
                {
                    _dispDate = value;
                }
                else
                {
                    _dispDate = new DateTime(
                        value.Year, value.Month, value.Day, _dispDate.Hour, _dispDate.Minute, _dispDate.Second);
                }
            }
        }

        [XmlElement(ElementName = "Disp_Date")]
        public string DispDateAsString
        {
            get
            {
                return _dispDate == default ? default : _dispDate.ToString(DateFormat);
            }
            set
            {
                DateTime dispDate = DateTime.Parse(value, CultureInfo.InvariantCulture);

                if (_dispDate == default)
                {
                    _dispDate = dispDate;
                }
                else
                {
                    _dispDate = new DateTime(
                        dispDate.Year, dispDate.Month, dispDate.Day, _dispDate.Hour, _dispDate.Minute, _dispDate.Second);
                }
            }
        }

        [XmlElement(ElementName = "Disp_Time")]
        public string DispTimeAsString
        {
            get
            {
                return _dispDate == default ? default : _dispDate.ToString("hh:mm:ss");
            }
            set
            {
                TimeSpan timeSpan = TimeSpan.Parse(value, CultureInfo.InvariantCulture);

                if (_dispDate == default)
                {
                    _dispDate = DateTime.Now;
                }

                _dispDate = new DateTime(
                        _dispDate.Year, _dispDate.Month, _dispDate.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            }
        }

        [XmlElement(ElementName = "APr_Code")]
        public string AprCode { get; set; }

        [XmlIgnore]
        public DateTime DiagDate
        {
            get { return _diagDate; }
            set { _diagDate = value; }
        }

        [XmlElement(ElementName = "Diag_Date")]
        public string DiagDateAsString
        {
            get
            {
                return _diagDate == default ? default : _diagDate.ToString(DateFormat);
            }
            set
            {
                _diagDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlIgnore]
        public DateTime? DispancerDate
        {
            get { return _dispancerDate; }
            set { _dispancerDate = value; }
        }

        [XmlElement(ElementName = "Dispancer_Date")]
        public string DispancerDateAsString
        {
            get
            {
                return _dispancerDate == default ? default : ((DateTime)_dispancerDate).ToString(DateFormat);
            }
            set
            {
                _dispancerDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "Disp_Visit")]
        public int DispVisit { get; set; }
        
        [XmlElement(ElementName = "MDI")]
        public List<MDI> MDIs { get; set; }

        [XmlElement(ElementName = "MainDiag1")]
        public Diag FirstMainDiag { get; set; }

        [XmlElement(ElementName = "MainDiag2")]
        public Diag SecondMainDiag { get; set; }

        [XmlElement(ElementName = "Anamnesa")]
        public string Anamnesa { get; set; }

        [XmlElement(ElementName = "HState")]
        public string HState { get; set; }

        [XmlElement(ElementName = "Therapy")]
        public string Therapy { get; set; }

        [XmlElement(ElementName = "Sign")]
        public int Sign { get; set; }

        [XmlElement(ElementName = "NZOKPay")]
        public int NZOKPay { get; set; }
    }
}
