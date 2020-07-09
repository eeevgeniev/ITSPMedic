using Medic.AppModels.VersionCodes;
using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.ClinicUsedDrugs
{
    public class ClinicUsedDrugViewModel
    {
        [Display(Name = MedicDataAnnotationLocalizerProvider.DrugDate)]
        public DateTime DrugDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DrugCode)]
        public string DrugCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DrugName)]
        public string DrugName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DrugQuantity)]
        public decimal DrugQuantity { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DrugCost)]
        public decimal DrugCost { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ICDDrug)]
        public string ICDDrug { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.UINPrescr)]
        public string UINPrescr { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.NoPrescr)]
        public string NoPrescr { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DatePrescr)]
        public DateTime DatePrescr { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PracticeCodeProtocol)]
        public string PracticeCodeProtocol { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProtocolNumber)]
        public int ProtocolNumber { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProtocolDate)]
        public DateTime ProtocolDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProtocolType)]
        public int ProtocolType { get; set; }

        public VersionCodeViewModel VersionCode { get; set; }
    }
}
