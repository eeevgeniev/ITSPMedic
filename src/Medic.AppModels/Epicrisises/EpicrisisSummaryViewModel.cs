using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Epicrisises
{
    public class EpicrisisSummaryViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(History))]
        public string History { get; set; }

        [Display(Name = nameof(FairCondition))]
        public string FairCondition { get; set; }

        [Display(Name = nameof(ClinicalExaminations))]
        public string ClinicalExaminations { get; set; }

        [Display(Name = nameof(Consultations))]
        public string Consultations { get; set; }

        [Display(Name = nameof(Regimen))]
        public string Regimen { get; set; }

        [Display(Name = nameof(DiseaseCourse))]
        public string DiseaseCourse { get; set; }

        [Display(Name = nameof(Complications))]
        public string Complications { get; set; }

        [Display(Name = nameof(DateOfSurgery))]
        public DateTime? DateOfSurgery { get; set; }

        [Display(Name = nameof(SampleProtocol))]
        public string SampleProtocol { get; set; }

        [Display(Name = nameof(PostoperativeStatus))]
        public string PostoperativeStatus { get; set; }

        [Display(Name = nameof(DischargeStatus))]
        public string DischargeStatus { get; set; }

        [Display(Name = nameof(Recommendations))]
        public string Recommendations { get; set; }

        [Display(Name = nameof(CheckupAfterDischarge))]
        public string CheckupAfterDischarge { get; set; }

        [Display(Name = nameof(GPRecommendations))]
        public string GPRecommendations { get; set; }

        [Display(Name = nameof(OtherDocuments))]
        public string OtherDocuments { get; set; }
    }
}
