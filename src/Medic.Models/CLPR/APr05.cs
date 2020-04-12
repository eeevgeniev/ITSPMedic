using Medic.Models.CP;
using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class APr05
    {
        private DateTime _diagDate;
        
        [XmlIgnore]
        public DateTime DiagnoseDate
        {
            get { return _diagDate; }
            set { _diagDate = value; }
        }

        [XmlElement(ElementName = "date_Diag")]
        public string DiagnoseDateAsString
        {
            get
            {
                if (_diagDate == default)
                {
                    return string.Empty;
                }

                return _diagDate.ToString("yyyy-MM-dd");
            }
            set
            {
                _diagDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        public Histology Histology { get; set; }

        public string Staging { get; set; }

        public string Imuno { get; set; }

        public string Genetic { get; set; }

        [XmlElement(ElementName = "Part_Hematology")]
        public ClinicHematologyPart ClinicHematologyPart { get; set; }

        [XmlElement(ElementName = "Part_Chemotherapy")]
        public ClinicChemotherapyPart ClinicChemotherapyPart { get; set; }

        public string Sign { get; set; }

        public int NZOKPay { get; set; }
    }
}