using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class DoneProcedure
    {
        private DateTime? _procedureStartDate;
        private DateTime? _procedureEndDate;

        [XmlIgnore]
        public DateTime? ProcedureStartDate 
        {
            get { return _procedureStartDate; }
            set { _procedureStartDate = value; }
        }

        [XmlIgnore]
        public DateTime? ProcedureEndDate 
        {
            get { return _procedureEndDate; }
            set { _procedureEndDate = value; } 
        }

        [XmlElement(ElementName = "Date_Proc")]
        public string ProcedureDateAsString
        {
            get
            {
                return _procedureStartDate == default ? default : ((DateTime)_procedureStartDate).ToString("yyyy-MM-dd");
            }
            set
            {
                _procedureStartDate = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "Time_Begin")]
        public string TimeBegin
        {
            get 
            { 
                if (_procedureStartDate == default)
                {
                    return default;
                }

                DateTime tempDate = (DateTime)_procedureStartDate;

                return $"{tempDate.Hour}:{tempDate.Minute}:{tempDate.Second}"; 
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    int[] values = GetTimeValues(value);

                    if (_procedureStartDate != default)
                    {
                        DateTime tempDate = (DateTime)_procedureStartDate;

                        _procedureStartDate = new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, values[0], values[1], values[2]);
                    }
                    else
                    {
                        _procedureStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, values[0], values[1], values[2]);
                    }
                }
            }
        }

        [XmlElement(ElementName = "Time_End")]
        public string TimeEnd
        {
            get 
            { 
                if (_procedureEndDate == default)
                {
                    return default;
                }

                DateTime tempDate = (DateTime)_procedureEndDate;

                return $"{tempDate.Hour}:{tempDate.Minute}:{tempDate.Second}"; 
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    int[] values = GetTimeValues(value);

                    if (_procedureEndDate != default)
                    {
                        DateTime tempDate = (DateTime)_procedureStartDate;

                        _procedureEndDate = new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, values[0], values[1], values[2]);
                    }
                    else
                    {
                        _procedureEndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, values[0], values[1], values[2]);
                    }
                }
            }
        }

        [XmlElement(ElementName = "Doctor_Name")]
        public string DoctorName { get; set; }

        private int[] GetTimeValues(string timeAsString)
        {
            MatchCollection matches = Regex.Matches(timeAsString, "\\d{2}");

            if (matches.Count != 3)
            {
                throw new InvalidOperationException(nameof(TimeSpan));
            }

            int[] values = new int[3];
            int counter = 0;

            foreach (Match match in matches)
            {
                values[counter++] = int.Parse(match.Value);
            }

            return values;
        }
    }
}