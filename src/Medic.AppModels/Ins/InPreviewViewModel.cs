using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.AppModels.Ins
{
    public class InPreviewViewModel
    {
        public int Id { get; set; }

        public DateTime EntryDate { get; set; }

        public string SendDiagnoseCode { get; set; }

        public string SendDiagnoseName { get; set; }

        public int PatientId { get; set; }

        public List<string> CodeDiagnoses { get; set; }
    }
}