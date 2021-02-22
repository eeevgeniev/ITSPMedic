using Medic.AppModels.CeasedClinicals;
using Medic.AppModels.ClinicProcedures;
using Medic.AppModels.ClinicUsedDrugs;
using Medic.AppModels.Diags;
using Medic.AppModels.DoneProcedures;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.Patients;
using Medic.AppModels.Procedures;
using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.PathProcedures
{
    public class PathProcedureViewModel
    {
        public int Id { get; set; }

        public PatientSummaryViewModel Patient { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientBranch)]
        public string PatientBranch { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientHRegion)]
        public string PatientHRegion { get; set; }

        public HealthcarePractitionerSummaryViewModel Sender { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CPrSend)]
        public string CPrSend { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.APrSend)]
        public string APrSend { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.TypeProcSend)]
        public int TypeProcSend { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DateSend)]
        public DateTime DateSend { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CPrPriem)]
        public string CPrPriem { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.APrPriem)]
        public string APrPriem { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MedicalWard)]
        public string MedicalWard { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.TypeProcPriem)]
        public int TypeProcPriem { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProcRefuse)]
        public int ProcRefuse { get; set; }

        public CeasedClinicalViewModel CeasedProcedure { get; set; }

        public CeasedClinicalViewModel CeasedClinicalPath { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.IZNumChild)]
        public string IZNumChild { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.IZYearChild)]
        public int IZYearChild { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.FirstVisitDate)]
        public DateTime? FirstVisitDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DatePlanPriem)]
        public DateTime? DatePlanPriem { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.VisitDoctorUniqueIdentifier)]
        public string VisitDoctorUniqueIdentifier { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.VisitDoctorName)]
        public string VisitDoctorName { get; set; }

        public DiagPreviewViewModel FirstMainDiag { get; set; }

        public DiagPreviewViewModel SecondMainDiag { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DateProcedureBegins)]
        public DateTime? DateProcedureBegins { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DateProcedureEnd)]
        public DateTime? DateProcedureEnd { get; set; }

        public List<ProcedureSummaryViewModel> DoneNewProcedures { get; set; }

        public List<ClinicUsedDrugViewModel> UsedDrugs { get; set; }

        public List<ClinicProcedureViewModel> ClinicProcedures { get; set; }

        public List<DoneProcedureViewModel> DoneProcedures { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.AllDoneProcedures)]
        public int? AllDoneProcedures { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.AllDrugCost)]
        public decimal? AllDrugCost { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientStatus)]
        public int PatientStatus { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OutUniqueIdentifier)]
        public string OutUniqueIdentifier { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Sign)]
        public int Sign { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.NZOKPay)]
        public int NZOKPay { get; set; }
    }
}
