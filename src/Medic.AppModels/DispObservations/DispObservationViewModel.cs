using Medic.AppModels.Diags;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.MDIs;
using Medic.AppModels.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.DispObservations
{
    public class DispObservationViewModel
    {
        public int Id { get; set; }

        public PatientSummaryViewModel Patient { get; set; }

        [Display(Name = nameof(PatientBranch))]
        public string PatientBranch { get; set; }

        [Display(Name = nameof(PatientHRegion))]
        public string PatientHRegion { get; set; }

        public HealthcarePractitionerSummaryViewModel Sender { get; set; }

        public HealthcarePractitionerSummaryViewModel Doctor { get; set; }

        [Display(Name = nameof(DispNum))]
        public int DispNum { get; set; }

        [Display(Name = nameof(DispDate))]
        public DateTime DispDate { get; set; }

        [Display(Name = nameof(AprCode))]
        public string AprCode { get; set; }

        [Display(Name = nameof(DiagDate))]
        public DateTime DiagDate { get; set; }

        [Display(Name = nameof(DispancerDate))]
        public DateTime? DispancerDate { get; set; }
        
        [Display(Name = nameof(DispVisit))]
        public int DispVisit { get; set; }

        public List<MDISummaryViewModel> MDIs { get; set; }

        public DiagPreviewViewModel FirstMainDiag { get; set; }

        public DiagPreviewViewModel SecondMainDiag { get; set; }

        [Display(Name = nameof(Anamnesa))]
        public string Anamnesa { get; set; }

        [Display(Name = nameof(HState))]
        public string HState { get; set; }

        [Display(Name = nameof(Therapy))]
        public string Therapy { get; set; }

        [Display(Name = nameof(Sign))]
        public int Sign { get; set; }

        [Display(Name = nameof(NZOKPay))]
        public int NZOKPay { get; set; }
    }
}
