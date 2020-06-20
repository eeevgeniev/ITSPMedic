using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Procedures
{
    public class ProcedureSummaryViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Date)]
        public DateTime Date { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Code)]
        public decimal Code { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ACHICode)]
        public string ACHICode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OutHospital)]
        public int? OutHospital { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ImplantReferenceNumber)]
        public string ImplantReferenceNumber { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ImplantManufacturer)]
        public string ImplantManufacturer { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ImplantCode)]
        public string ImplantCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.BedDays)]
        public int? BedDays { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.HLDateFrom)]
        public DateTime? HLDateFrom { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.HLNumber)]
        public string HLNumber { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.HLTotalDays)]
        public int? HLTotalDays { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.StateAtDischarge)]
        public int? StateAtDischarge { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Laparoscopic)]
        public int? Laparoscopic { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PathologicFinding)]
        public int? PathologicFinding { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.EndCourse)]
        public int? EndCourse { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendApr)]
        public string SendAPr { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.InApr)]
        public string InAPr { get; set; }
    }
}
