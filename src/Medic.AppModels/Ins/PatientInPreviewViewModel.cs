using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Ins
{
    public class PatientInPreviewViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = nameof(EntryDate))]
        public DateTime EntryDate { get; set; }

        [Display(Name = nameof(MKBCode))]
        public string MKBCode { get; set; }

        [Display(Name = nameof(MKBName))]
        public string MKBName { get; set; }
    }
}