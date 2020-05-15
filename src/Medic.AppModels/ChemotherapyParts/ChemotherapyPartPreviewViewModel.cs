using Medic.AppModels.Diags;
using Medic.AppModels.Evaluations;
using Medic.AppModels.GenMarkers;
using Medic.AppModels.Histologies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.ChemotherapyParts
{
    public class ChemotherapyPartPreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(DiagnoseDate))]
        public DateTime DiagnoseDate { get; set; }

        [Display(Name = nameof(ExpandDiagnose))]
        public string ExpandDiagnose { get; set; }

        public DiagPreviewViewModel AddDiag { get; set; }

        public HistologyPreviewViewModel Histology { get; set; }

        [Display(Name = nameof(ECOG))]
        public int ECOG { get; set; }

        [Display(Name = nameof(Staging))]
        public string Staging { get; set; }

        [Display(Name = nameof(TNM))]
        public string TNM { get; set; }

        public List<GenMarkerPreviewViewModel> GenMarkers { get; set; }

        [Display(Name = nameof(TherapyType))]
        public int TherapyType { get; set; }

        [Display(Name = nameof(EvalAfterCycle))]
        public int EvalAfterCycle { get; set; }

        [Display(Name = nameof(Interval))]
        public int Interval { get; set; }

        public EvaluationPreviewViewModel Evaluation { get; set; }
    }
}
