using Medic.AppModels.TherapyTypes;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.AccompanyingDrugs
{
    public class AccompanyingDrugPreviewViewModel
    {
        public int Id { get; set; }

        public TherapyTypePreviewViewModel TherapyType { get; set; }

        [Display(Name = nameof(ATCCode))]
        public string ATCCode { get; set; }

        [Display(Name = nameof(ATCName))]
        public string ATCName { get; set; }

        [Display(Name = nameof(SingleDose))]
        public decimal SingleDose { get; set; }

        [Display(Name = nameof(AllDose))]
        public decimal AllDose { get; set; }
    }
}
