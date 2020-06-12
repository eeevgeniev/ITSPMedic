using Medic.AppModels.Plannings;
using Medic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IPlannedService
    {
        Task<PlannedViewModel> GetPlannedAsync(int id);

        Task<List<PlannedPreviewViewModel>> GetPlanningsAsync(
            IWhereBuilder<Planned> plannedProcedureBuilder,
            IHelperBuilder<Planned> helperBuilder,
            int startIndex);

        Task<int> GetPlanningsCountAsync(IWhereBuilder<Planned> plannedProcedureBuilder);
    }
}
