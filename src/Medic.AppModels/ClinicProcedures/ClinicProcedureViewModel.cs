using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.ClinicProcedures
{
    public class ClinicProcedureViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProcedureName)]
        public string ProcedureName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProcedureCode)]
        public decimal ProcedureCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProcedureDate)]
        public DateTime ProcedureDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ACHICode)]
        public string ACHIcode { get; set; }
    }
}
