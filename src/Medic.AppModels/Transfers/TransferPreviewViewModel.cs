using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Transfers
{
    public class TransferPreviewViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = MedicDataAnnotationLocalizerProvider.TransferDateTime)]
        public DateTime? TransferDateTime { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.FirstMainDiagCode)]
        public string FirstMainDiagCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.FirstMainDiagName)]
        public string FirstMainDiagName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SecondMainDiagCode)]
        public string SecondMainDiagCode{ get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SecondMainDiagName)]
        public string SecondMainDiagName { get; set; }
    }
}
