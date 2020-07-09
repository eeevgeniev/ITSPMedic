using Medic.AppModels.Diags;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.MDIs;
using Medic.AppModels.Patients;
using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.DispObservations
{
    public class DispObservationViewModel
    {
        public int Id { get; set; }

        public PatientSummaryViewModel Patient { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientBranch)]
        public string PatientBranch { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientHRegion)]
        public string PatientHRegion { get; set; }

        public HealthcarePractitionerSummaryViewModel Doctor { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DispNum)]
        public int DispNum { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DispDate)]
        public DateTime DispDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.AprCode)]
        public string AprCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DiagDate)]
        public DateTime DiagDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DispanserDate)]
        public DateTime? DispanserDate { get; set; }
        
        [Display(Name = MedicDataAnnotationLocalizerProvider.DispVisit)]
        public int DispVisit { get; set; }

        public List<MDISummaryViewModel> MDIs { get; set; }

        public DiagPreviewViewModel FirstMainDiag { get; set; }

        public DiagPreviewViewModel SecondMainDiag { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Anamnesa)]
        public string Anamnesa { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.HState)]
        public string HState { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Therapy)]
        public string Therapy { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Sign)]
        public int Sign { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.NZOKPay)]
        public int NZOKPay { get; set; }
    }
}
