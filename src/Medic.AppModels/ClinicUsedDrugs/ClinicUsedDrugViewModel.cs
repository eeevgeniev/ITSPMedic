using Medic.AppModels.VersionCodes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.ClinicUsedDrugs
{
    public class ClinicUsedDrugViewModel
    {
        [Display(Name = nameof(DrugDate))]
        public DateTime DrugDate { get; set; }

        [Display(Name = nameof(DrugCode))]
        public string DrugCode { get; set; }

        [Display(Name = nameof(DrugName))]
        public string DrugName { get; set; }

        [Display(Name = nameof(DrugQuantity))]
        public decimal DrugQuantity { get; set; }

        [Display(Name = nameof(DrugCost))]
        public decimal DrugCost { get; set; }

        [Display(Name = nameof(ICDDrug))]
        public string ICDDrug { get; set; }

        [Display(Name = nameof(UINPrescr))]
        public string UINPrescr { get; set; }

        [Display(Name = nameof(NoPrescr))]
        public string NoPrescr { get; set; }

        [Display(Name = nameof(DatePrescr))]
        public DateTime DatePrescr { get; set; }

        [Display(Name = nameof(PracticeCodeProtocol))]
        public string PracticeCodeProtocol { get; set; }

        [Display(Name = nameof(ProtocolNumber))]
        public int ProtocolNumber { get; set; }

        [Display(Name = nameof(ProtocolDate))]
        public DateTime ProtocolDate { get; set; }

        [Display(Name = nameof(ProtocolType))]
        public int ProtocolType { get; set; }

        public VersionCodeViewModel VersionCode { get; set; }
    }
}
