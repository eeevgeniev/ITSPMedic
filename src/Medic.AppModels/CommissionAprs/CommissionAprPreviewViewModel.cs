using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.CommissionAprs
{
    public class CommissionAprPreviewViewModel
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendDate)]
        public DateTime SendDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MainDiagCode)]
        public string MainDiagCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MainDiagName)]
        public string MainDiagName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.AddDiagCodes)]
        public List<String> AddDiagCodes { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.APr05sImuno)]
        public string APr05sImuno { get; set; }

        public string CutAPr05sImuno(int length)
        {
            if (string.IsNullOrWhiteSpace(APr05sImuno) || APr05sImuno.Length <= length)
            {
                return APr05sImuno;
            }

            while (char.IsLetterOrDigit(APr05sImuno[length]) && length > 30)
            {
                length--;
            }

            return $"{APr05sImuno.Substring(0, length)}...";
        }
    }
}
