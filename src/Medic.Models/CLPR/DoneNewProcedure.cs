using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class DoneNewProcedure
    {
        private const string DateFormat = "yyyy-MM-ddTHH:mm:ss";

        private DateTime _procedureDate;

        [XmlElement(ElementName = "Code_Proc")]
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
                return _procedureDate == default ? default : _procedureDate.ToString(DateFormat);
            }
            set
            {
                _procedureDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "ACHIcode")]
        public string ACHICode { get; set;  }
    }
}
