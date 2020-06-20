using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.CommissionAprs
{
    public class CommissionAprPreviewViewModel
    {
        private string _imuno;
        
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
        public string APr05sImuno 
        { 
            get { return _imuno; }
            set 
            {
                int length = 50;

                if (string.IsNullOrWhiteSpace(value) || value.Length <= 50)
                {
                    _imuno = value;
                    return;
                }

                while (char.IsLetterOrDigit(value[length]) && length > 30)
                {
                    length--;
                }

                _imuno = $"{value.Substring(0, length)}...";
            }
        }
    }
}
