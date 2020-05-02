using System;

namespace Medic.AppModels.Epicrisises
{
    public class EpicrisisSummaryViewModel
    {
        public int Id { get; set; }

        public string History { get; set; }

        public string FairCondition { get; set; }

        public string ClinicalExaminations { get; set; }

        public string Consultations { get; set; }

        public string Regimen { get; set; }

        public string DiseaseCourse { get; set; }

        public string Complications { get; set; }

        public DateTime? DateOfSurgery { get; set; }

        public string SampleProtocol { get; set; }

        public string PostoperativeStatus { get; set; }

        public string DischargeStatus { get; set; }

        public string Recommendations { get; set; }

        public string CheckupAfterDischarge { get; set; }

        public string GPRecommendations { get; set; }

        public string OtherDocuments { get; set; }
    }
}
