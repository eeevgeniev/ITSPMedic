using Medic.AppModels.APr05s;
using Medic.AppModels.APr38s;
using Medic.AppModels.Diags;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.Patients;
using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.CommissionAprs
{
    public class CommissionAprViewModel
    {
        public int Id { get; set; }

        public PatientSummaryViewModel Patient { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientBranch)]
        public string PatientBranch { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientHRegion)]
        public string PatientHRegion { get; set; }

        public HealthcarePractitionerSummaryViewModel Sender { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.APrSend)]
        public double? AprSend { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendDate)]
        public DateTime SendDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.APrPriem)]
        public double? AprPriem { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SpecCommission)]
        public int SpecCommission { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.NoDecision)]
        public int NoDecision { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DecisionDate)]
        public DateTime DecisionDate { get; set; }

        public HealthcarePractitionerSummaryViewModel Chairman { get; set; }

        public DiagPreviewViewModel MainDiag { get; set; }

        public List<DiagPreviewViewModel> AddDiags { get; set; }

        public APr38PreviewViewModel APr38 { get; set; }

        public APr05PreviewViewModel APr05 { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Sign)]
        public int Sign { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.NZOKPay)]
        public int NZOKPay { get; set; }
    }
}
