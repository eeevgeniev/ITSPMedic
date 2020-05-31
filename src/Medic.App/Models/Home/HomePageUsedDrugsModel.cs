using Medic.App.Models.Bases;
using Medic.AppModels.UsedDrugs;
using System.Collections.Generic;

namespace Medic.App.Models.Home
{
    public class HomePageUsedDrugsModel : BasePageSummaryModel
    {
        public List<UsedDrugsSummaryStatistic> UsedDrugsSummary { get; set; }
    }
}
