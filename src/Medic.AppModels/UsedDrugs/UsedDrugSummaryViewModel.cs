using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.UsedDrugs
{
    public class UsedDrugSummaryViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(Date))]
        public DateTime Date { get; set; }

        [Display(Name = nameof(Code))]
        public string Code { get; set; }

        [Display(Name = nameof(Quantity))]
        public decimal Quantity { get; set; }

        [Display(Name = nameof(Cost))]
        public decimal Cost { get; set; }

        [Display(Name = nameof(ICDDrug))]
        public string ICDDrug { get; set; }

        [Display(Name = nameof(UINPrescr))]
        public string UINPrescr { get; set; }

        [Display(Name = nameof(NoPrescr))]
        public string NoPrescr { get; set; }

        [Display(Name = nameof(DatePrescr))]
        public DateTime? DatePrescr { get; set; }

        [Display(Name = nameof(PracticeCodeProtocol))]
        public string PracticeCodeProtocol { get; set; }

        [Display(Name = nameof(ProtocolNumber))]
        public int ProtocolNumber { get; set; }

        [Display(Name = nameof(ProtocolDate))]
        public DateTime ProtocolDate { get; set; }

        [Display(Name = nameof(ProtocolType))]
        public int ProtocolType { get; set; }

        [Display(Name = nameof(BatchNumber))]
        public string BatchNumber { get; set; }

        [Display(Name = nameof(QuantityPack))]
        public decimal QuantityPack { get; set; }
    }
}
