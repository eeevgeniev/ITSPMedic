using Medic.App.Models.Bases;
using Medic.AppModels.UsedDrugs;
using System.Collections.Generic;

namespace Medic.App.Models.Home
{
    public class HomePageUsedDrugsModel : BasePageModel
    {
        public List<UsedDrugsSummaryStatistic> UsedDrugsSummary { get; set; }
    }
}
