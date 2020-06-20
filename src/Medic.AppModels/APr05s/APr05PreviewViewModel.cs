using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.APr05s
{
    public class APr05PreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DiagnoseDate)]
        public DateTime DiagnoseDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Staging)]
        public string Staging { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Imuno)]
        public string Imuno { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Genetic)]
        public string Genetic { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Sign)]
        public string Sign { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.NZOKPay)]
        public int NZOKPay { get; set; }
    }
}
