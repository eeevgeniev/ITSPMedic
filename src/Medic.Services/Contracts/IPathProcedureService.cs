using Medic.AppModels.PathProcedures;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IPathProcedureService
    {
        public Task<PathProcedureViewModel> GetPathProcedureByIdAsync(int id);
    }
}