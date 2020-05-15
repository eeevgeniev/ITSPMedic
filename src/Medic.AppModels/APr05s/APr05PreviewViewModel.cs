using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.APr05s
{
    public class APr05PreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(DiagnoseDate))]
        public DateTime DiagnoseDate { get; set; }

        [Display(Name = nameof(Staging))]
        public string Staging { get; set; }

        [Display(Name = nameof(Imuno))]
        public string Imuno { get; set; }

        [Display(Name = nameof(Genetic))]
        public string Genetic { get; set; }

        [Display(Name = nameof(Sign))]
        public string Sign { get; set; }

        [Display(Name = nameof(NZOKPay))]
        public int NZOKPay { get; set; }
    }
}
