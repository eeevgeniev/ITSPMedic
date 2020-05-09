using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.Logs.Models
{
    public class Log
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string InnerExceptionMessage { get; set; }

        public string StackTrace { get; set; }

        public string Source { get; set; }

        public DateTime Date { get; set; }
    }
}
