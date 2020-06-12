using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Patient
    {
        private const string DateFormat = "yyyy-MM-dd";

        private DateTime _birthDate;
        private DateTime? _dateTo;
        private DateTime? _dateFrom;
        private DateTime? _dateIssue;

        [XmlElement(ElementName = "COUNTRYCODE")]
        public string CountryCode { get; set; }

        [XmlElement(ElementName = "Institution_ID")]
        public string InstitutionId { get; set; }

        [XmlElement(ElementName = "Institution_Name")]
        public string InstitutionName { get; set; }

        [XmlElement(ElementName = "Type_CERTIFICATE")]
        public string CertificateType { get; set; }

        [XmlIgnore]
        public DateTime? DateTo
        {
            get { return _dateTo; }
            set { _dateTo = value; }
        }

        [XmlElement(ElementName = "DateTo")]
        public string DateToAsString
        {
            get
            {
                return _dateTo == default ? default : ((DateTime)_dateTo).ToString(DateFormat);
            }
            set
            {
                _dateTo = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlIgnore]
        public DateTime? DateFrom
        {
            get { return _dateFrom; }
            set { _dateFrom = value; }
        }

        [XmlElement(ElementName = "DateFrom")]
        public string DateFromAsString
        {
            get
            {
                return _dateFrom == default ? default : ((DateTime)_dateFrom).ToString(DateFormat);
            }
            set
            {
                _dateFrom = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlIgnore]
        public DateTime? DateIssue
        {
            get { return _dateIssue; }
            set { _dateIssue = value; }
        }

        [XmlElement(ElementName = "DateIssue")]
        public string DateIssueAsString
        {
            get
            {
                return _dateIssue == default ? default : ((DateTime)_dateIssue).ToString(DateFormat);
            }
            set
            {
                _dateIssue = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "EHIC_No")]
        public string EhicC { get; set; }

        [XmlElement(ElementName = "PersID_No")]
        public string PersonalIdNumber { get; set; }

        [XmlElement(ElementName = "Notes")]
        public string Notes { get; set; }

        [XmlElement(ElementName = "EGN")]
        public string IdentityNumber { get; set; }

        [XmlElement(ElementName = "SS_No")]
        public string NAPNumber { get; set; }

        [XmlIgnore]
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        [XmlElement(ElementName = "dateBirth")]
        public string BirthDateAsString
        {
            get
            {
                return _birthDate == default ? default : _birthDate.ToString(DateFormat);
            }
            set
            {
                _birthDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "Lead_Doc_Name")]
        public string LeadDocName { get; set; }

        [XmlElement(ElementName = "Sex")]
        public int Sex { get; set; }

        [XmlElement(ElementName = "Given")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "Sur")]
        public string SecondName { get; set; }

        [XmlElement(ElementName = "Family")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "Address")]
        public string Address { get; set; }

        [XmlElement(ElementName = "LNCH")]
        public string LNCH { get; set; }

        [XmlElement(ElementName = "personType")]
        public int? PersonType { get; set; }
    }
}
