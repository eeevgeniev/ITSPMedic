using Medic.Logs.Models;
using System.Threading.Tasks;

namespace Medic.Logs.Contracts
{
    public interface IMedicLoggerService
    {
        Task<int> SaveAsync(Log model);
    }
}
