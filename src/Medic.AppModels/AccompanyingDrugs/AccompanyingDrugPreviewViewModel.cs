using Medic.AppModels.TherapyTypes;
using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.AccompanyingDrugs
{
    public class AccompanyingDrugPreviewViewModel
    {
        public int Id { get; set; }

        public TherapyTypePreviewViewModel TherapyType { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ATCCode)]
        public string ATCCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ATCName)]
        public string ATCName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SingleDose)]
        public decimal SingleDose { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.AllDose)]
        public decimal AllDose { get; set; }
    }
}
