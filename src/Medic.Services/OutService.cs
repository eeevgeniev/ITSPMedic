using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.Outs;
using Medic.Contexts;
using Medic.Entities;
using Medic.Services.Contracts;
using Medic.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class OutService : IOutService
    {
        private readonly MedicContext MedicContext;
        private readonly MapperConfiguration Configuration;

        public OutService(MedicContext medicContext, MapperConfiguration configuration)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<OutViewModel> GetOutAsyns(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            return await MedicContext.Outs
                .ProjectTo<OutViewModel>(Configuration)
                .SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<OutPreviewViewModel>> GetOutsAsync(
            IWhereBuilder<Out> outBuilder, 
            IHelperBuilder<Out> helperBuilder, 
            int startIndex)
        {
            if (outBuilder == default)
            {
                throw new ArgumentNullException(nameof(outBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }
            
            return await helperBuilder.BuildQuery(outBuilder.Where(MedicContext.Outs).Skip(startIndex))
                .ProjectTo<OutPreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetOutsCountAsync(IWhereBuilder<Out> outBuilder)
        {
            if (outBuilder == default)
            {
                throw new ArgumentNullException(nameof(outBuilder));
            }

            return await outBuilder.Where(MedicContext.Outs)
                .CountAsync();
        }
    }
}
