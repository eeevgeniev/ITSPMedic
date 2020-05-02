using Medic.App.Models.Bases;
using Medic.AppModels.Diagnoses;
using System.Collections.Generic;

namespace Medic.App.Models.Home
{
    public class HomePageDiagnoseModel : BasePageModel
    {
        public List<DiagnoseMKBSummaryViewModel> DiagnosesMKBSummaryViewModels { get; set; }
    }
}
