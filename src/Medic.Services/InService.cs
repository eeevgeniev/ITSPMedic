using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.Ins;
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
    public class InService : IInService
    {
        private readonly MedicContext MedicContext;
        private readonly MapperConfiguration Configuration;

        public InService(MedicContext medicContext, MapperConfiguration configuration)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<InViewModel> GetInAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            return await MedicContext.Ins
                .ProjectTo<InViewModel>(Configuration)
                .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<InPreviewViewModel>> GetInsAsync(
            IWhereBuilder<In> inBuilder, 
            IHelperBuilder<In> helperBuilder, 
            int startIndex)
        {
            if (inBuilder == default)
            {
                throw new ArgumentNullException(nameof(inBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(inBuilder.Where(MedicContext.Ins).Skip(startIndex))
                .ProjectTo<InPreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetInsCountAsync(IWhereBuilder<In> inBuilder)
        {
            if (inBuilder == default)
            {
                throw new ArgumentNullException(nameof(inBuilder));
            }

            return await inBuilder.Where(MedicContext.Ins)
                .CountAsync();
        }
    }
}
