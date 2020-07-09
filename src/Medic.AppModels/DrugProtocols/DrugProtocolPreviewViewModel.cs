using Medic.AppModels.TherapyTypes;
using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.DrugProtocols
{
    public class DrugProtocolPreviewViewModel
    {
        public int Id { get; set; }

        public TherapyTypePreviewViewModel TherapyType { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ATCCode)]
        public string ATCCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ATCName)]
        public string ATCName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Days)]
        public string Days { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ApplicationWay)]
        public string ApplicationWay { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.StandartDose)]
        public decimal StandartDose { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.IndividualDose)]
        public decimal IndividualDose { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CycleDose)]
        public decimal CycleDose { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.AllDose)]
        public decimal AllDose { get; set; }
    }
}
