using Medic.AppModels.Diagnoses;
using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Ins
{
    public class PatientInPreviewViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = MedicDataAnnotationLocalizerProvider.EntryDate)]
        public DateTime EntryDate { get; set; }

        public List<DiagnosePreviewViewModel> SendDiagnoses { get; set; }
    }
}