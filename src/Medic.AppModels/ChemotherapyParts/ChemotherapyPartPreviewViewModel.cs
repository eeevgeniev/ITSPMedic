using Medic.AppModels.Diags;
using Medic.AppModels.Evaluations;
using Medic.AppModels.GenMarkers;
using Medic.AppModels.Histologies;
using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.ChemotherapyParts
{
    public class ChemotherapyPartPreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DiagnoseDate)]
        public DateTime DiagnoseDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ExpandDiagnose)]
        public string ExpandDiagnose { get; set; }

        public List<DiagPreviewViewModel> AddDiags { get; set; }

        public HistologyPreviewViewModel Histology { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ECOG)]
        public int ECOG { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Staging)]
        public string Staging { get; set; }

        [Display(Name = nameof(TNM))]
        public string TNM { get; set; }

        public List<GenMarkerPreviewViewModel> GenMarkers { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.TherapyType)]
        public int TherapyType { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.EvalAfterCycle)]
        public int EvalAfterCycle { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Interval)]
        public int Interval { get; set; }

        public EvaluationPreviewViewModel Evaluation { get; set; }

        public int? Status { get; set; }
    }
}
