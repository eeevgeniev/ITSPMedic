using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> Epicrisis
    /// </summary>
    [Serializable]
    public partial class Epicrisis : BaseEntity, IModelBuilder, IModelTransformer
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

        public Out Out { get; set; } 

        public string DoctorsNames { get; set; }
    }
}
