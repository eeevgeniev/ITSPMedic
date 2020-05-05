﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Ins
{
    public class InsSerach
    {
        [Display(Name = nameof(MainDiagnose))]
        public string MainDiagnose { get; set; }

        [Display(Name = nameof(CountOfAdditionalDiagnoses))]
        public int? CountOfAdditionalDiagnoses { get; set; }

        [Display(Name = nameof(Sex))]
        public int? Sex { get; set; }

        [Display(Name = nameof(Diagnoses))]
        public List<string> Diagnoses { get; set; }

        [Display(Name = nameof(Age))]
        public int? Age { get; set; }

        [Display(Name = nameof(OlderThan))]
        public int? OlderThan { get; set; }

        [Display(Name = nameof(YoungerThan))]
        public int? YoungerThan { get; set; }
    }
}
