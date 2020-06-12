using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.PathProcedures
{
    public class PathProcedurePreviewViewModel
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

        [Display(Name = nameof(UsedDrugCodes))]
        public List<string> UsedDrugCodes { get; set; }
    }
}
