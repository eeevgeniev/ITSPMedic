using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    [XmlRoot(ElementName = "cpFile")]
    public class CPFile
    {
        private DateTime _dateFrom;
        private DateTime _dateTo;

        public Practice Practice { get; set; }

        [XmlElement(ElementName = "fileType")]
        public string FileType { get; set; }

        [XmlIgnore]
        public DateTime DateFrom
        {
            get { return _dateFrom; }
            set { _dateFrom = value; }
        }

        [XmlElement(ElementName = "dateFrom")]
        public string DateFromAsString 
        { 
            get
            {
                if (_dateFrom == default)
                {
                    return string.Empty;
                }
                
                return _dateFrom.ToString("yyyy-MM-ddTHH:mm:ss");
            }
            set
            {
                _dateFrom = DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        [XmlIgnore]
        public DateTime DateTo
        {
            get { return _dateTo; }
            set { _dateTo = value; }
        }

        [XmlElement(ElementName = "dateTo")]
        public string DateToAsString
        {
            get
            {
                if (_dateTo == default)
                {
                    return string.Empty;
                }

                return _dateTo.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            }
            set
            {
                _dateTo = DateTime.ParseExact(value, "yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "Planned")]
        public List<PlannedProcedure> PlannedProcedures { get; set; }

        [XmlElement(ElementName = "In")]
        public List<In> Ins { get; set; }

        [XmlElement(ElementName = "Out")]
        public List<Out> Outs { get; set; }

        [XmlElement(ElementName = "Protocol_DrugTherapy")]
        public List<ProtocolDrugTherapy> ProtocolDrugTherapies { get; set; }

        [XmlElement(ElementName = "PatientTransfers")]
        public List<PatientTransfer> PatientTransfers { get; set; }
    }
}