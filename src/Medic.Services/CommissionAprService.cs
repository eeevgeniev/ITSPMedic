using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.CommissionAprs;
using Medic.Contexts;
using Medic.Entities;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<CommissionAprPreviewViewModel>> GetCommissionAprsAsync(
            IWhereBuilder<CommissionApr> commissionAprWhereBuilder, 
            IHelperBuilder<CommissionApr> helperBuilder, 
            int startIndex)
        {
            if (commissionAprWhereBuilder == default)
            {
                throw new ArgumentNullException(nameof(commissionAprWhereBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(commissionAprWhereBuilder.Where(MedicContext.CommissionAprs).Skip(startIndex))
                .ProjectTo<CommissionAprPreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetCommissionAprsCountAsync(IWhereBuilder<CommissionApr> commissionAprWhereBuilder)
        {
            if (commissionAprWhereBuilder == default)
            {
                throw new ArgumentNullException(nameof(commissionAprWhereBuilder));
            }

            return await commissionAprWhereBuilder.Where(MedicContext.CommissionAprs)
                .CountAsync();
        }
    }
}