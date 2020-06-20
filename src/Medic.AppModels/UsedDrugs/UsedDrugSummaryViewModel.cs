using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.UsedDrugs
{
    public class UsedDrugSummaryViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Date)]
        public DateTime Date { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Code)]
        public string Code { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Quantity)]
        public decimal Quantity { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Cost)]
        public decimal Cost { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ICDDrug)]
        public string ICDDrug { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.UINPrescr)]
        public string UINPrescr { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.NoPrescr)]
        public string NoPrescr { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DatePrescr)]
        public DateTime? DatePrescr { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PracticeCodeProtocol)]
        public string PracticeCodeProtocol { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProtocolNumber)]
        public int ProtocolNumber { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProtocolDate)]
        public DateTime ProtocolDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProtocolType)]
        public int ProtocolType { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.BatchNumber)]
        public string BatchNumber { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.QuantityPack)]
        public decimal QuantityPack { get; set; }
    }
}
