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
                return _diagDate == default ? default : _diagDate.ToString("yyyy-MM-dd");
            }
            set
            {
                _diagDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "Histology")]
        public Histology Histology { get; set; }

        [XmlElement(ElementName = "Staging")]
        public string Staging { get; set; }

        [XmlElement(ElementName = "Imuno")]
        public string Imuno { get; set; }

        [XmlElement(ElementName = "Genetic")]
        public string Genetic { get; set; }

        [XmlElement(ElementName = "Part_Hematology")]
        public ClinicHematologyPart ClinicHematologyPart { get; set; }

        [XmlElement(ElementName = "Part_Chemotherapy")]
        public ClinicChemotherapyPart ClinicChemotherapyPart { get; set; }

        [XmlElement(ElementName = "Sign")]
        public string Sign { get; set; }

        [XmlElement(ElementName = "NZOKPay")]
        public int NZOKPay { get; set; }
    }
}