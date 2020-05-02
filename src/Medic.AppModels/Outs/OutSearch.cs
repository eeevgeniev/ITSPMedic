using System.Collections.Generic;

namespace Medic.AppModels.Outs
{
    public class OutSearch
    {
        public string MainOutDiagnose { get; set; }

        public int? NumberOfAdditionalOutDiagnoses { get; set; }

        public int? Sex { get; set; }

        public string SendDiagnose { get; set; }

        public int? NumberOfAdditionalDiagnoses { get; set; }

        public List<string> Diagnoses { get; set; }

        public string UsedDrug { get; set; }

        public int? Age { get; set; }

        public int? OlderThan { get; set; }

        public int? YoungerThan { get; set; }
    }
}
