using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class ProtocolDrugTherapy
    {
        private const string DateFormat = "yyyy-MM-dd";

        private DateTime _decisionDate;
        private DateTime _protocolDate;

        [XmlElement(ElementName = "Patient")]
        public Patient Patient { get; set; }

        [XmlElement(ElementName = "patientBranch")]
        public int? PatientBranch { get; set; }

        [XmlElement(ElementName = "patientHRegion")]
        public int? PatientHRegion { get; set; }

        [XmlElement(ElementName = "PracticeZdrRajon")]
        public int? PracticeRegion { get; set; }

        [XmlElement(ElementName = "PracticeCode")]
        public string PracticeCode { get; set; }

        [XmlElement(ElementName = "PracticeName")]
        public string PracticeName { get; set; }

        [XmlElement(ElementName = "No_Decision")]
        public int NumberOfDecision { get; set; }

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

        [XmlElement(ElementName = "PracticeCode_Protocol")]
        public string PracticeCodeProtocol { get; set; }

        [XmlElement(ElementName = "No_Protocol")]
        public int NumberOfProtocol { get; set; }

        [XmlIgnore]
        public DateTime ProtocolDate
        {
            get { return _protocolDate; }
            set { _protocolDate = value; }
        }

        [XmlElement(ElementName = "date_Protocol")]
        public string ProtocolDateAsString
        {
            get
            {
                return _protocolDate == default ? default : _protocolDate.ToString(DateFormat);
            }
            set
            {
                _protocolDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "Diag")]
        public Diag Diag { get; set; }

        [XmlElement(ElementName = "height")]
        public int Height { get; set; }

        [XmlElement(ElementName = "weight")]
        public int Weight { get; set; }

        [XmlElement(ElementName = "BSA")]
        public double BSA { get; set; }

        [XmlElement(ElementName = "Line_Therapy")]
        public int TherapyLine { get; set; }

        public string Scheme { get; set; }

        [XmlElement(ElementName = "Cycle_Count")]
        public int CycleCount { get; set; }

        [XmlElement(ElementName = "Part_Hematology")]
        public HematologyPart HematologyPart { get; set; }

        [XmlElement(ElementName = "Part_Chemotherapy")]
        public ChemotherapyPart ChemotherapyPart { get; set; }

        [XmlElement(ElementName = "Prot_Drug")]
        public List<DrugProtocol> DrugProtocols { get; set; }

        [XmlElement(ElementName = "Accompanying_Drug")]
        public List<AccompanyingDrug> AccompanyingDrugs { get; set; }

        public Chairman Chairman { get; set; }

        [XmlElement(ElementName = "Members")]
        public List<Member> Members { get; set; }

        [XmlElement(ElementName = "Sign")]
        public int Sign { get; set; }
    }
}