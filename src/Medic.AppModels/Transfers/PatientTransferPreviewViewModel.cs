using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Transfers
{
    public class PatientTransferPreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.TransferDateTime)]
        public DateTime? TransferDateTime { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MKBCode)]
        public string MKBCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MKBName)]
        public string MKBName { get; set; }
    }
}
