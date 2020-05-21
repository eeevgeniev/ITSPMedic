using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Ins
{
    public class InsSerach
    {
        [Display(Name = nameof(MainDiagnose))]
        public string MainDiagnose { get; set; }

        [Display(Name = nameof(CountOfAdditionalDiagnoses))]
        public int? CountOfAdditionalDiagnoses { get; set; }

        [Display(Name = nameof(Sex))]
        public int? Sex { get; set; }

        [Display(Name = nameof(HealthRegion))]
        public int? HealthRegion { get; set; }

        [Display(Name = nameof(Age))]
        public int? Age { get; set; }

        [Display(Name = nameof(OlderThan))]
        public int? OlderThan { get; set; }

        [Display(Name = nameof(YoungerThan))]
        public int? YoungerThan { get; set; }

        public override string ToString()
        {
            return $"{nameof(MainDiagnose)}:{MainDiagnose}&{nameof(CountOfAdditionalDiagnoses)}:{CountOfAdditionalDiagnoses}&{nameof(Sex)}:{Sex}&" +
                $"{nameof(HealthRegion)}:{HealthRegion}&{nameof(Age)}:{Age}&{nameof(OlderThan)}:{OlderThan}&{nameof(YoungerThan)}:{YoungerThan}";
        }
    }
}
