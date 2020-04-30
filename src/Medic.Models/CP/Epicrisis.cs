using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Epicrisis
    {
        private DateTime? _dateOfSurgery;

        [XmlElement(ElementName = "history")]
        public string History { get; set; }

        [XmlElement(ElementName = "fairCondition")]
        public string FairCondition { get; set; }

        [XmlElement(ElementName = "clinicalExaminations")]
        public string ClinicalExaminations { get; set; }

        [XmlElement(ElementName = "consultations")]
        public string Consultations { get; set; }

        [XmlElement(ElementName = "regimen")]
        public string Regimen { get; set; }

        [XmlElement(ElementName = "diseaseCourse")]
        public string DiseaseCourse { get; set; }

        [XmlElement(ElementName = "complications")]
        public string Complications { get; set; }

        [XmlIgnore]
        public DateTime? DateOfSurgery
        {
            get { return _dateOfSurgery; }
            set { _dateOfSurgery = value; }
        }

        [XmlElement(ElementName = "dateOfSurgery")]
        public string DateOfSurgeryAsString
        {
            get
            {
                return _dateOfSurgery == default ? default : ((DateTime)_dateOfSurgery).ToString("yyyy-MM-hh");
            }
            set
            {
                _dateOfSurgery = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "sampleProtocol")]
        public string SampleProtocol { get; set; }

        [XmlElement(ElementName = "postoperativeStatus")]
        public string PostoperativeStatus { get; set; }

        [XmlElement(ElementName = "dischargeStatus")]
        public string DischargeStatus { get; set; }

        [XmlElement(ElementName = "Recommendations")]
        public string Recommendations { get; set; }

        [XmlElement(ElementName = "checkupAfterDischarge")]
        public string CheckupAfterDischarge { get; set; }

        [XmlElement(ElementName = "GPRecommendations")]
        public string GPRecommendations { get; set; }

        [XmlElement(ElementName = "otherDocuments")]
        public string OtherDocuments { get; set; }

        [XmlElement(ElementName = "doctorsNames")]
        public string DoctorsNames { get; set; }
    }
}