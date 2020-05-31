using Medic.AppModels.PlannedProcedures;
using Medic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IPlannedProcedureService
    {
        Task<PlannedProcedureViewModel> GetPlannedProcedureAsync(int id);

        Task<List<PlannedProcedurePreviewViewModel>> GetPlannedProceduresAsync(
            IWhereBuilder<PlannedProcedure> plannedProcedureBuilder,
            IHelperBuilder<PlannedProcedure> helperBuilder,
            int startIndex);

        Task<int> GetPlannedProceduresCountAsync(IWhereBuilder<PlannedProcedure> plannedProcedureBuilder);
    }
}
