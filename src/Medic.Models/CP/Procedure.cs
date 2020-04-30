using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Procedure
    {
        private const string DateFormat = "yyyy-MM-dd";

        private DateTime _date;
        private DateTime? _hLDateFrom;

        [XmlElement(ElementName = "code")]
        public double Code { get; set; }

        [XmlElement(ElementName = "ACHIcode")]
        public string ACHICode { get; set; }

        [XmlElement(ElementName = "outHosp")]
        public int OutHosp { get; set; }

        [XmlIgnore]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        [XmlElement(ElementName = "date")]
        public string DateAsString
        {
            get
            {
                return _date == default ? default : _date.ToString(DateFormat);
            }
            set
            {
                _date = DateTime.ParseExact(value, DateFormat, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "Implant", IsNullable = false)]
        public Implant Implant { get; set; }

        [XmlElement(ElementName = "bedDays")]
        public int BedDays { get; set; }

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
                _hLDateFrom = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "HLNo")]
        public string HLNumber { get; set; }

        public int HLTotalDays { get; set; }

        [XmlElement(ElementName = "stateAtDischarge")]
        public int StateAtDischarge { get; set; }

        public int Laparoscopic { get; set; }

        [XmlElement(ElementName = "Pathologic_Finding")]
        public int PathologicFinding { get; set; }

        public int EndCourse { get; set; }

        [XmlElement(ElementName = "sendAPr")]
        public string SendAPr { get; set; }

        [XmlElement(ElementName = "InAPr")]
        public string InAPr { get; set; }
    }
}