using Medic.AppModels.Diagnoses;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.Patients;
using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Plannings
{
    public class PlannedViewModel
    {
        public int Id { get; set; }

        public PatientSummaryViewModel Patient { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientBranch)]
        public string PatientBranch { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientHRegion)]
        public string PatientHRegion { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.InType)]
        public int InType { get; set; }

        public HealthcarePractitionerSummaryViewModel Sender { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendDate)]
        public DateTime SendDate { get; set; }

        public List<DiagnosePreviewViewModel> SendDiagnoses { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendUrgency)]
        public int SendUrgency { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendPackageType)]
        public int? SendPackageType { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendClinicalPath)]
        public double? SendClinicalPath { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendApr)]
        public int? SendAPr { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.UniqueIdentifier)]
        public string UniqueIdentifier { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ExaminationDate)]
        public DateTime ExaminationDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PlannedEntryDate)]
        public DateTime? PlannedEntryDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PlannedNumber)]
        public int PlannedNumber { get; set; }

        public List<DiagnosePreviewViewModel> Diagnoses { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Urgency)]
        public int Urgency { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PackageType)]
        public int? PackageType { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ClinicalPath)]
        public double? ClinicalPath { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.InApr)]
        public int? InAPr { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.NZOKPay)]
        public int NZOKPay { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CPFile)]
        public string CPFile { get; set; }
    }
}
