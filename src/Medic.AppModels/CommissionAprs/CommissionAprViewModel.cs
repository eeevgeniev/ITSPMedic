using Medic.AppModels.APr05s;
using Medic.AppModels.APr38s;
using Medic.AppModels.Diags;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.CommissionAprs
{
    public class CommissionAprViewModel
    {
        public int Id { get; set; }

        public PatientSummaryViewModel Patient { get; set; }

        [Display(Name = nameof(PatientBranch))]
        public string PatientBranch { get; set; }

        [Display(Name = nameof(PatientHRegion))]
        public string PatientHRegion { get; set; }

        public HealthcarePractitionerSummaryViewModel Sender { get; set; }

        [Display(Name = nameof(AprSend))]
        public double? AprSend { get; set; }

        [Display(Name = nameof(SendDate))]
        public DateTime SendDate { get; set; }

        [Display(Name = nameof(AprPriem))]
        public double? AprPriem { get; set; }

        [Display(Name = nameof(SpecCommission))]
        public int SpecCommission { get; set; }

        [Display(Name = nameof(NoDecision))]
        public int NoDecision { get; set; }

        [Display(Name = nameof(DecisionDate))]
        public DateTime DecisionDate { get; set; }

        public HealthcarePractitionerSummaryViewModel Chairman { get; set; }

        public DiagPreviewViewModel MainDiag { get; set; }

        public List<DiagPreviewViewModel> AddDiags { get; set; }

        public APr38PreviewViewModel APr38 { get; set; }

        public APr05PreviewViewModel APr05 { get; set; }

        [Display(Name = nameof(Sign))]
        public int Sign { get; set; }

        [Display(Name = nameof(NZOKPay))]
        public int NZOKPay { get; set; }
    }
}
