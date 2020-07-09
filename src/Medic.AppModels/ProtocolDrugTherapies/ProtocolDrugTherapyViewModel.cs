using Medic.AppModels.AccompanyingDrugs;
using Medic.AppModels.ChemotherapyParts;
using Medic.AppModels.Diags;
using Medic.AppModels.DrugProtocols;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.HematologyParts;
using Medic.AppModels.Patients;
using Medic.AppModels.Practices;
using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.ProtocolDrugTherapies
{
    public class ProtocolDrugTherapyViewModel
    {
        public int Id { get; set; }

        public PatientSummaryViewModel Patient { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientBranch)]
        public string PatientBranch { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientHRegion)]
        public string PatientHRegion { get; set; }

        public PracticePreviewViewModel Practice { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.NumberOfDecision)]
        public int NumberOfDecision { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DecisionDate)]
        public DateTime DecisionDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PracticeCodeProtocol)]
        public string PracticeCodeProtocol { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.NumberOfProtocol)]
        public int NumberOfProtocol { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProtocolDate)]
        public DateTime ProtocolDate { get; set; }

        public DiagPreviewViewModel Diag { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Height)]
        public int Height { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Weight)]
        public int Weight { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.BSA)]
        public double BSA { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.TherapyLine)]
        public int TherapyLine { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Scheme)]
        public string Scheme { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CycleCount)]
        public int CycleCount { get; set; }

        public HematologyPartPreviewViewModel HematologyPart { get; set; }

        public ChemotherapyPartPreviewViewModel ChemotherapyPart { get; set; }

        public List<DrugProtocolPreviewViewModel> DrugProtocols { get; set; }

        public List<AccompanyingDrugPreviewViewModel> AccompanyingDrugs { get; set; }

        public HealthcarePractitionerSummaryViewModel Chairman { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Sign)]
        public int Sign { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CPFile)]
        public string CPFile { get; set; }
    }
}
