using System.Collections.Generic;

namespace Medic.AppModels.Ins
{
    public class InsSerach
    {
        public string MainDiagnose { get; set; }

        public int? NumberOfAdditionalDiagnoses { get; set; }

        public int? Sex { get; set; }

        public List<string> Diagnoses { get; set; }

        public int? Age { get; set; }

        public int? OlderThan { get; set; }

        public int? YoungerThan { get; set; }
    }
}
