using Medic.Logs.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Medic.Logs.Contracts
{
    public interface IMedicLoggerContext
    {
        DbSet<Log> Logs { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}