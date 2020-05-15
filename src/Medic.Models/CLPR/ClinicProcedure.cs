using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class ClinicProcedure
    {
        private DateTime _procedureDate;

        [XmlElement(ElementName = "imeP")]
        public string ProcedureName { get; set; }

        [XmlElement(ElementName = "kodP")]
        public decimal ProcedureCode { get; set; }

        [XmlIgnore]
        public DateTime ProcedureDate
        {
            get { return _procedureDate; }
            set { _procedureDate = value; }
        }

        [XmlElement(ElementName = "Date_Proc")]
        public string ProcedureDateAsString
        {
            get
            {
                return _procedureDate == default ? default : _procedureDate.ToString("yyyy-MM-dd");
            }
            set
            {
                _procedureDate = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "ACHIcode")]
        public string ACHIcode { get; set; }
    }
}