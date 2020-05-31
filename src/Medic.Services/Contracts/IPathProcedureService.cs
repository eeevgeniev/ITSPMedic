using Medic.AppModels.PathProcedures;
using Medic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IPathProcedureService
    {
        public Task<PathProcedureViewModel> GetPathProcedureByIdAsync(int id);

        Task<List<PathProcedurePreviewViewModel>> GetPathProceduresAsync(
            IWhereBuilder<PathProcedure> pathProcedureBuilder,
            IHelperBuilder<PathProcedure> helperBuilder,
            int startIndex);

        Task<int> GetPathProceduresCountAsync(IWhereBuilder<PathProcedure> pathProcedureBuilder);
    }
}