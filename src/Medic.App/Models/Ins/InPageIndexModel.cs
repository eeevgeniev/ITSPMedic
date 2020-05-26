using Medic.App.Models.Bases;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.Ins;
using Medic.AppModels.Sexes;
using System.Collections.Generic;

namespace Medic.App.Models.Ins
{
    public class InPageIndexModel : BasePageModel
    {
        public InsSearch Search { get; set; }

        public List<InPreviewViewModel> Ins { get; set; }

        public int CurrentPage { get; set; }

        public int TotalCount { get; set; }

        public List<HealthRegionOption> HealthRegions { get; set; }

        public List<SexOption> Sexes { get; set; }
    }
}