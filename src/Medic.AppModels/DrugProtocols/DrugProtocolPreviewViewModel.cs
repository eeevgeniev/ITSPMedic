using Medic.AppModels.TherapyTypes;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.DrugProtocols
{
    public class DrugProtocolPreviewViewModel
    {
        public int Id { get; set; }

        public TherapyTypePreviewViewModel TherapyType { get; set; }

        [Display(Name = nameof(ATCCode))]
        public string ATCCode { get; set; }

        [Display(Name = nameof(ATCName))]
        public string ATCName { get; set; }

        [Display(Name = nameof(Days))]
        public string Days { get; set; }

        [Display(Name = nameof(ApplicationWay))]
        public string ApplicationWay { get; set; }

        [Display(Name = nameof(StandartDose))]
        public decimal StandartDose { get; set; }

        [Display(Name = nameof(IndividualDose))]
        public decimal IndividualDose { get; set; }

        [Display(Name = nameof(CycleDose))]
        public decimal CycleDose { get; set; }

        [Display(Name = nameof(AllDose))]
        public decimal AllDose { get; set; }
    }
}
