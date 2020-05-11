using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Outs
{
    public class OutSearch
    {
        [Display(Name = nameof(MainOutDiagnose))]
        public string MainOutDiagnose { get; set; }

        [Display(Name = nameof(CountOfAdditionalOutDiagnoses))]
        public int? CountOfAdditionalOutDiagnoses { get; set; }

        [Display(Name = nameof(Sex))]
        public int? Sex { get; set; }

        [Display(Name = nameof(SendDiagnose))]
        public string SendDiagnose { get; set; }

        [Display(Name = nameof(CountOfAdditionalSendDiagnoses))]
        public int? CountOfAdditionalSendDiagnoses { get; set; }

        [Display(Name = nameof(HealthRegion))]
        public int? HealthRegion { get; set; }

        [Display(Name = nameof(UsedDrug))]
        public string UsedDrug { get; set; }

        [Display(Name = nameof(Age))]
        public int? Age { get; set; }

        [Display(Name = nameof(OlderThan))]
        public int? OlderThan { get; set; }

        [Display(Name = nameof(YoungerThan))]
        public int? YoungerThan { get; set; }

        public override string ToString()
        {
            return $"{nameof(MainOutDiagnose)}:{MainOutDiagnose}&{nameof(CountOfAdditionalOutDiagnoses)}:{CountOfAdditionalOutDiagnoses}&{nameof(Sex)}:{Sex}&{nameof(SendDiagnose)}:{SendDiagnose}&" +
                $"{nameof(CountOfAdditionalSendDiagnoses)}:{CountOfAdditionalSendDiagnoses}&{nameof(HealthRegion)}:{HealthRegion}&{nameof(UsedDrug)}:{UsedDrug}&{nameof(Age)}:{Age}&{nameof(OlderThan)}:{OlderThan}&{nameof(YoungerThan)}:{YoungerThan}";
        }
    }
}
