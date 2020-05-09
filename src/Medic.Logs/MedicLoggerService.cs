using Medic.Logs.Contracts;
using Medic.Logs.Models;
using System;
using System.Threading.Tasks;

namespace Medic.Logs
{
    public class MedicLoggerService : IMedicLoggerService
    {
        private readonly MedicLoggerContext MedicLoggerContext;

        public MedicLoggerService(MedicLoggerContext medicLoggerContext)
        {
            MedicLoggerContext = medicLoggerContext ?? throw new ArgumentNullException(nameof(medicLoggerContext));
        }

        public async Task<int> SaveAsync(Log model)
        {
            await MedicLoggerContext.Logs.AddAsync(model);
            return await MedicLoggerContext.SaveChangesAsync();
        }
    }
}
