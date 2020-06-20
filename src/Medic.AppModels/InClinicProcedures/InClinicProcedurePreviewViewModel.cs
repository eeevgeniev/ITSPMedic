using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.InClinicProcedures
{
    public class InClinicProcedurePreviewViewModel
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        
        [Display(Name = MedicDataAnnotationLocalizerProvider.DateSend)]
        public DateTime DateSend { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.FirstMainDiagCode)]
        public string FirstMainDiagCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.FirstMainDiagName)]
        public string FirstMainDiagName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SecondMainDiagCode)]
        public string SecondMainDiagCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SecondMainDiagName)]
        public string SecondMainDiagName { get; set; }
    }
}
