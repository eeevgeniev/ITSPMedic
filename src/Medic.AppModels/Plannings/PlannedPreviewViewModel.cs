using Medic.AppModels.Diagnoses;
using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Plannings
{
    public class PlannedPreviewViewModel
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.UniqueIdentifier)]
        public string UniqueIdentifier { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendDate)]
        public DateTime SendDate { get; set; }

        public List<DiagnosePreviewViewModel> Diagnoses { get; set; }

        public List<DiagnosePreviewViewModel> SendDiagnoses { get; set; }
    }
}
