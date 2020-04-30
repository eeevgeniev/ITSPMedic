using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    [XmlRoot(ElementName = "Transfer")]
    public class PatientTransfer
    {
        private DateTime? _transferDateTime;

        public int IZYear { get; set; }

        public int IZNumber { get; set; }

        [XmlElement(ElementName = "MainDiag1")]
        public Diag FirstMainDiag { get; set; }

        public int CashPatient { get; set; }

        [XmlElement(ElementName = "clinicalProcedure")]
        public int ClinicalProcedure { get; set; }

        [XmlElement(ElementName = "clinicalPath")]
        public int ClinicalPath { get; set; }

        [XmlElement(ElementName = "dischargeWard")]
        public decimal DischargeWard { get; set; }

        [XmlElement(ElementName = "transferWard")]
        public decimal TransferWard { get; set; }

        [XmlIgnore]
        public DateTime? TransferDateTime
        {
            get { return _transferDateTime; }
            set { _transferDateTime = value; }
        }

        [XmlElement(ElementName = "transferDateTime")]
        public string TransferDateTimeAsString
        {
            get
            {
                return _transferDateTime == default ? default : ((DateTime)_transferDateTime).ToString("yyyy-MM-ddTHH:mm:ss");
            }
            set
            {
                _transferDateTime = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }
    }
}
