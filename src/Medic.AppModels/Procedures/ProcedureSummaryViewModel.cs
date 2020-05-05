using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Procedures
{
    public class ProcedureSummaryViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(Date))]
        public DateTime Date { get; set; }

        [Display(Name = nameof(Code))]
        public decimal Code { get; set; }

        [Display(Name = nameof(ACHICode))]
        public string ACHICode { get; set; }

        [Display(Name = nameof(OutHospital))]
        public int? OutHospital { get; set; }

        [Display(Name = nameof(ImplantReferenceNumber))]
        public string ImplantReferenceNumber { get; set; }

        [Display(Name = nameof(ImplantManufacturer))]
        public string ImplantManufacturer { get; set; }

        [Display(Name = nameof(ImplantCode))]
        public string ImplantCode { get; set; }

        [Display(Name = nameof(BedDays))]
        public int? BedDays { get; set; }

        [Display(Name = nameof(HLDateFrom))]
        public DateTime? HLDateFrom { get; set; }

        [Display(Name = nameof(HLNumber))]
        public string HLNumber { get; set; }

        [Display(Name = nameof(HLTotalDays))]
        public int? HLTotalDays { get; set; }

        [Display(Name = nameof(StateAtDischarge))]
        public int? StateAtDischarge { get; set; }

        [Display(Name = nameof(Laparoscopic))]
        public int? Laparoscopic { get; set; }

        [Display(Name = nameof(PathologicFinding))]
        public int? PathologicFinding { get; set; }

        [Display(Name = nameof(EndCourse))]
        public int? EndCourse { get; set; }

        [Display(Name = nameof(SendAPr))]
        public string SendAPr { get; set; }

        [Display(Name = nameof(InAPr))]
        public string InAPr { get; set; }
    }
}
