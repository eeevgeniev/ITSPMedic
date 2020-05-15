using Medic.Models.CP;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class CommissionApr
    {
        private const string DateFormat = "yyyy-MM-dd";

        private DateTime _sendDate;
        private DateTime _decisionDate;

        [XmlElement(ElementName = "Patient")]
        public Patient Patient { get; set; }

        [XmlElement(ElementName = "patientBranch")]
        public int? PatientBranch { get; set; }

        [XmlElement(ElementName = "patientHRegion")]
        public int? PatientHRegion { get; set; }

        [XmlElement(ElementName = "Sender")]
        public Sender Sender { get; set; }

        [XmlElement(ElementName = "APr_Send")]
        public double? AprSend { get; set; }

        [XmlIgnore]
        public DateTime SendDate
        {
            get { return _sendDate; }
            set { _sendDate = value; }
        }

        [XmlElement(ElementName = "Date_Send")]
        public string DiagDateAsString
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

        [XmlElement(ElementName = "APr_Priem")]
        public double? AprPriem { get; set; }

        [XmlElement(ElementName = "Spec_Commission")]
        public int SpecCommission { get; set; }

        [XmlElement(ElementName = "No_Decision")]
        public int NoDecision { get; set; }

        [XmlIgnore]
        public DateTime DecisionDate
        {
            get { return _decisionDate; }
            set { _decisionDate = value; }
        }

        [XmlElement(ElementName = "date_Decision")]
        public string DecisionDateAsString
        {
            get
            {
                return _decisionDate == default ? default : _decisionDate.ToString(DateFormat);
            }
            set
            {
                _decisionDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        public Chairman Chairman { get; set; }

        [XmlElement(ElementName = "Members")]
        public List<Member> Members { get; set; }

        [XmlElement(ElementName = "MainDiag")]
        public Diag MainDiag { get; set; }

        [XmlElement(ElementName = "AddDiag")]
        public List<Diag> AddDiag { get; set; }

        [XmlElement(ElementName = "APr38")]
        public APr38 APr38 { get; set; }

        [XmlElement(ElementName = "APr05")]
        public APr05 APr05 { get; set; }

        [XmlElement(ElementName = "Sign")]
        public int Sign { get; set; }

        [XmlElement(ElementName = "NZOKPay")]
        public int NZOKPay { get; set; }
    }
}
