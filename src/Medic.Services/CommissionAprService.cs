using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.CommissionAprs;
using Medic.Contexts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class CommissionAprService : ICommissionAprService
    {
        private readonly MedicContext MedicContext;
        private readonly MapperConfiguration Configuration;

        public CommissionAprService(MedicContext medicContext, MapperConfiguration configuration)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<CommissionAprViewModel> GetCommissionAprAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }
            
            return await MedicContext.CommissionAprs
                    .ProjectTo<CommissionAprViewModel>(Configuration)
                    .SingleOrDefaultAsync(ca => ca.Id == id);
        }
    }
}