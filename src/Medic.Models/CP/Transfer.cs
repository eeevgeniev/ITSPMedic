using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Transfer
    {
        private DateTime? _transferDateTime;

        [XmlElement(ElementName = "IZYear")]
        public int IZYear { get; set; }

        [XmlElement(ElementName = "IZNo")]
        public int IZNumber { get; set; }

        [XmlElement(ElementName = "MainDiag1")]
        public Diag FirstMainDiag { get; set; }

        [XmlElement(ElementName = "MainDiag2")]
        public Diag SecondMainDiag { get; set; }

        [XmlElement(ElementName = "cashPatient")]
        public int CashPatient { get; set; }

        [XmlElement(ElementName = "clinicalProcedure")]
        public int ClinicalProcedure { get; set; }

        [XmlElement(ElementName = "ambulatoryProcedure")]
        public string AmbulatoryProcedure { get; set; }

        [XmlElement(ElementName = "clinicalPath")]
        public double ClinicalPath { get; set; }

        [XmlElement(ElementName = "dischargeWard")]
        public double DischargeWard { get; set; }

        [XmlElement(ElementName = "transferWard")]
        public double TransferWard { get; set; }

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
