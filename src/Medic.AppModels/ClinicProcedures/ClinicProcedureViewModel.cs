using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.ClinicProcedures
{
    public class ClinicProcedureViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(ProcedureName))]
        public string ProcedureName { get; set; }

        [Display(Name = nameof(ProcedureCode))]
        public decimal ProcedureCode { get; set; }

        [Display(Name = nameof(ProcedureDate))]
        public DateTime ProcedureDate { get; set; }

        [Display(Name = nameof(ACHIcode))]
        public string ACHIcode { get; set; }
    }
}
