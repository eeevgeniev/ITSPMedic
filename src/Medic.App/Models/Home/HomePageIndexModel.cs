using Medic.App.Models.Bases;
using Medic.AppModels.CPFiles;
using Medic.AppModels.Diagnoses;
using Medic.AppModels.Diags;
using Medic.AppModels.HospitalPractices;
using System.Collections.Generic;

namespace Medic.App.Models.Home
{
    public class HomePageModel : BasePageModel
    {
        public List<CPFileSummaryViewModel> CPFileSummaryViewModels { get; set; }

        public List<HospitalPracticeSummaryViewModel> HospitalPracticeSummaryViewModels { get; set; }

        public int PatientCount { get; set; }
    }
}
