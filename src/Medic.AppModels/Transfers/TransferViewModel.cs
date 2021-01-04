using Medic.AppModels.Diags;
using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Transfers
{
    public class TransferViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.IZYear)]
        public int IZYear { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.IZNumber)]
        public int IZNumber { get; set; }

        public DiagPreviewViewModel FirstMainDiag { get; set; }

        public DiagPreviewViewModel SecondMainDiag { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CashPatient)]
        public int CashPatient { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ClinicalProcedure)]
        public int ClinicalProcedure { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ClinicalPath)]
        public double ClinicalPath { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.AmbulatoryProcedure)]
        public string AmbulatoryProcedure { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DischargeWard)]
        public double DischargeWard { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.TransferWard)]
        public double TransferWard { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.TransferDateTime)]
        public DateTime? TransferDateTime { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.IZYear)]
        public string CPFile { get; set; }
    }
}
