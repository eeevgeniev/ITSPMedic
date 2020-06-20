using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Epicrisises
{
    public class EpicrisisSummaryViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.History)]
        public string History { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.FairCondition)]
        public string FairCondition { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ClinicalExaminations)]
        public string ClinicalExaminations { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Consultations)]
        public string Consultations { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Regimen)]
        public string Regimen { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DiseaseCourse)]
        public string DiseaseCourse { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Complications)]
        public string Complications { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DateOfSurgery)]
        public DateTime? DateOfSurgery { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SampleProtocol)]
        public string SampleProtocol { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PostoperativeStatus)]
        public string PostoperativeStatus { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DischargeStatus)]
        public string DischargeStatus { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Recommendations)]
        public string Recommendations { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CheckupAfterDischarge)]
        public string CheckupAfterDischarge { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.GPRecommendations)]
        public string GPRecommendations { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OtherDocuments)]
        public string OtherDocuments { get; set; }
    }
}
