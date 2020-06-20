using Medic.AppModels.Diagnoses;
using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Outs
{
    public class OutPreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.UniqueIdentifier)]
        public string UniqueIdentifier { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OutDate)]
        public DateTime OutDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OutMainDiagnoseCode)]
        public string OutMainDiagnoseCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OutMainDiagnoseName)]
        public string OutMainDiagnoseName { get; set; }

        public int PatientId { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendDiagnoses)]
        public List<DiagnosePreviewViewModel> SendDiagnoses { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Diagnoses)]
        public List<DiagnosePreviewViewModel> Diagnoses { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OutDiagnoses)]
        public List<DiagnosePreviewViewModel> OutDiagnoses { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.UsedDrugCodes)]
        public List<string> UsedDrugCodes { get; set; }
    }
}
