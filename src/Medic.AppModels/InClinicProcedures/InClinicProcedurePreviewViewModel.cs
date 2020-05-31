using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.InClinicProcedures
{
    public class InClinicProcedurePreviewViewModel
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        
        [Display(Name = nameof(DateSend))]
        public DateTime DateSend { get; set; }

        [Display(Name = nameof(FirstMainDiagCode))]
        public string FirstMainDiagCode { get; set; }

        [Display(Name = nameof(FirstMainDiagName))]
        public string FirstMainDiagName { get; set; }

        [Display(Name = nameof(SecondMainDiagCode))]
        public string SecondMainDiagCode { get; set; }

        [Display(Name = nameof(SecondMainDiagName))]
        public string SecondMainDiagName { get; set; }
    }
}
