using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> ProtocolDrugTherapy
    /// </summary>
    [Serializable]
    public partial class ProtocolDrugTherapy : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int? PatientId { get; set; }

        public Patient Patient { get; set; }

        public int? PatientBranchId { get; set; }

        public PatientBranch PatientBranch { get; set; }

        public int? PatientHRegionId { get; set; }

        public HealthRegion PatientHRegion { get; set; }

        public int? PracticeId { get; set; }

        public Practice Practice { get; set; }

        public int NumberOfDecision { get; set; }

        public DateTime DecisionDate { get; set; }

        public string PracticeCodeProtocol { get; set; }

        public int NumberOfProtocol { get; set; }

        public DateTime ProtocolDate { get; set; }

        public DateTime? StartTreatment { get; set; }

        public int? DiagId { get; set; }
        
        public Diag Diag { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public double BSA { get; set; }

        public int TherapyLine { get; set; }

        public string Scheme { get; set; }

        public int CycleCount { get; set; }

        public int? HematologyPartId { get; set; }

        public HematologyPart HematologyPart { get; set; }

        public int? ChemotherapyPartId { get; set; }

        public ChemotherapyPart ChemotherapyPart { get; set; }

        public ICollection<DrugProtocol> DrugProtocols { get; set; } = new HashSet<DrugProtocol>();

        public ICollection<AccompanyingDrug> AccompanyingDrugs { get; set; } = new HashSet<AccompanyingDrug>();

        public int? ChairmanId { get; set; }

        public HealthcarePractitioner Chairman { get; set; }

        public ICollection<ProtocolDrugTherapyHealthPractitioner> Members { get; set; } = new HashSet<ProtocolDrugTherapyHealthPractitioner>();

        public int? HospitalPracticeId { get; set; }

        public HospitalPractice HospitalPractice { get; set; }

        public int Sign { get; set; }

        public int? CPFileId { get; set; }

        public CPFile CPFile { get; set; }
    }
}