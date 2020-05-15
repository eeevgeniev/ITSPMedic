using Medic.AppModels.AccompanyingDrugs;
using Medic.AppModels.ChemotherapyParts;
using Medic.AppModels.Diags;
using Medic.AppModels.DrugProtocols;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.HematologyParts;
using Medic.AppModels.Patients;
using Medic.AppModels.Practices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.ProtocolDrugTherapies
{
    public class ProtocolDrugTherapyViewModel
    {
        public int Id { get; set; }

        public PatientSummaryViewModel Patient { get; set; }

        [Display(Name = nameof(PatientBranch))]
        public string PatientBranch { get; set; }

        [Display(Name = nameof(PatientHRegion))]
        public string PatientHRegion { get; set; }

        public PracticePreviewViewModel Practice { get; set; }

        [Display(Name = nameof(NumberOfDecision))]
        public int NumberOfDecision { get; set; }

        [Display(Name = nameof(DecisionDate))]
        public DateTime DecisionDate { get; set; }

        [Display(Name = nameof(PracticeCodeProtocol))]
        public string PracticeCodeProtocol { get; set; }

        [Display(Name = nameof(NumberOfProtocol))]
        public int NumberOfProtocol { get; set; }

        [Display(Name = nameof(ProtocolDate))]
        public DateTime ProtocolDate { get; set; }

        public DiagPreviewViewModel Diag { get; set; }

        [Display(Name = nameof(Height))]
        public int Height { get; set; }

        [Display(Name = nameof(Weight))]
        public int Weight { get; set; }

        [Display(Name = nameof(BSA))]
        public double BSA { get; set; }

        [Display(Name = nameof(TherapyLine))]
        public int TherapyLine { get; set; }

        [Display(Name = nameof(Scheme))]
        public string Scheme { get; set; }

        [Display(Name = nameof(CycleCount))]
        public int CycleCount { get; set; }

        public HematologyPartPreviewViewModel HematologyPart { get; set; }

        public ChemotherapyPartPreviewViewModel ChemotherapyPart { get; set; }

        public List<DrugProtocolPreviewViewModel> DrugProtocols { get; set; }

        public List<AccompanyingDrugPreviewViewModel> AccompanyingDrugs { get; set; }

        public HealthcarePractitionerSummaryViewModel Chairman { get; set; }

        [Display(Name = nameof(Sign))]
        public int Sign { get; set; }

        [Display(Name = nameof(CPFile))]
        public string CPFile { get; set; }
    }
}
