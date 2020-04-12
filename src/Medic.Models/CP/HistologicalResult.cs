using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class HistologicalResult
    {
        private DateTime _date;
        
        [XmlElement(ElementName = "code")]
        public decimal Code { get; set; }

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
              if (_date == default)
                {
                    return string.Empty;
                }
                
                return _date.ToString("yyyy-MM-dd"); 
            }
            set 
            { 
                _date = DateTime.Parse(value, CultureInfo.InvariantCulture); 
            }
        }

        [XmlElement(ElementName = "note")]
        public string Note { get; set; }
    }
}