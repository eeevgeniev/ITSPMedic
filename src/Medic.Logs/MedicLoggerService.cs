using Medic.Logs.Contracts;
using Medic.Logs.Models;
using System;
using System.Threading.Tasks;

namespace Medic.Logs
{
    public class MedicLoggerService : IMedicLoggerService
    {
        private readonly IMedicLoggerContext MedicLoggerContext;

        public MedicLoggerService(IMedicLoggerContext medicLoggerContext)
        {
            MedicLoggerContext = medicLoggerContext ?? throw new ArgumentNullException(nameof(medicLoggerContext));
        }

        public async Task<int> SaveAsync(Log model)
        {
            try
            {
                MedicLoggerContext.Logs.Add(model);

                return await MedicLoggerContext.SaveChangesAsync(default);
            }
            catch
            {

            }

            return -1;
        }
    }
}
