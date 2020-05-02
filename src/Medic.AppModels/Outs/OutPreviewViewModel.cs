using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.AppModels.Outs
{
    public class OutPreviewViewModel
    {
        public int Id { get; set; }

        public DateTime OutDate { get; set; }

        public string OutMainDiagnoseCode { get; set; }

        public string OutMainDiagnoseName { get; set; }

        public int PatientId { get; set; }

        public List<string> OutCodeDiagnoses { get; set; }

        public string SendDiagnoseCode { get; set; }

        public List<string> Diagnoses { get; set; }

        public string UsedDrugCode { get; set; }
    }
}
