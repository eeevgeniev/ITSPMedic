using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class DoneProcedure
    {
        private DateTime _procedureStartDate;
        private DateTime _procedureEndDate;

        [XmlIgnore]
        public DateTime ProcedureStartDate { get; set; }

        [XmlIgnore]
        public DateTime ProcedureEndDate { get; set; }

        [XmlElement(ElementName = "Date_Proc")]
        public string ProcedureDateAsString
        {
            get
            {
                if (_procedureStartDate == default)
                {
                    return string.Empty;
                }

                return _procedureStartDate.ToString("yyyy-MM-dd");
            }
            set
            {
                _procedureStartDate = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "Time_Begin")]
        public string TimeBegin
        {
            get { return $"{_procedureStartDate.Hour}:{_procedureStartDate.Minute}:{_procedureStartDate.Second}"; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    int[] values = GetTimeValues(value);

                    if (_procedureStartDate != default)
                    {
                        _procedureStartDate = new DateTime(_procedureStartDate.Year, _procedureStartDate.Month, _procedureStartDate.Day, values[0], values[1], values[2]);
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
            get { return $"{_procedureEndDate.Hour}:{_procedureEndDate.Minute}:{_procedureEndDate.Second}"; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    int[] values = GetTimeValues(value);

                    if (_procedureEndDate != default)
                    {
                        _procedureEndDate = new DateTime(_procedureEndDate.Year, _procedureEndDate.Month, _procedureEndDate.Day, values[0], values[1], values[2]);
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