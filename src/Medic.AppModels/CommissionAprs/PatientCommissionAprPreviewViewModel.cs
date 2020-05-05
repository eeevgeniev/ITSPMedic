﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.CommissionAprs
{
    public class PatientCommissionAprPreviewViewModel
    {
        [Display(Name = "DecisionDate")]
        public DateTime DecisionDate { get; set; }

        [Display(Name = "MKBCode")]
        public string MKBCode { get; set; }

        [Display(Name = "MKBName")]
        public string MKBName { get; set; }
    }
}
