using Medic.AppModels.Diagnoses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Plannings
{
    public class PatientPlannedPreviewViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = nameof(ExaminationDate))]
        public DateTime ExaminationDate { get; set; }

        public List<DiagnosePreviewViewModel> Diagnoses { get; set; }
    }
}
