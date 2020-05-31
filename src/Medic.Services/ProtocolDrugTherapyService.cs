using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.ProtocolDrugTherapies;
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
    public class ProtocolDrugTherapyService : IProtocolDrugTherapyService
    {
        private readonly MedicContext MedicContext;
        private readonly MapperConfiguration Configuration;

        public ProtocolDrugTherapyService(MedicContext medicContext, MapperConfiguration configuration)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<List<ProtocolDrugTherapyPreviewViewModel>> GetProtocolDrugTherapiesAsync(
            IWhereBuilder<ProtocolDrugTherapy> protocolDrugTherapyBuilder, 
            IHelperBuilder<ProtocolDrugTherapy> helperBuilder, 
            int startIndex)
        {
            if (protocolDrugTherapyBuilder == default)
            {
                throw new ArgumentNullException(nameof(protocolDrugTherapyBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(protocolDrugTherapyBuilder.Where(MedicContext.ProtocolDrugTherapies).Skip(startIndex))
                .ProjectTo<ProtocolDrugTherapyPreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetProtocolDrugTherapiesCountAsync(IWhereBuilder<ProtocolDrugTherapy> protocolDrugTherapyBuilder)
        {
            if (protocolDrugTherapyBuilder == default)
            {
                throw new ArgumentNullException(nameof(protocolDrugTherapyBuilder));
            }

            return await protocolDrugTherapyBuilder.Where(MedicContext.ProtocolDrugTherapies)
                .CountAsync();
        }

        public async Task<ProtocolDrugTherapyViewModel> GetProtocolDrugTherapyAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            return await MedicContext.ProtocolDrugTherapies
                .ProjectTo<ProtocolDrugTherapyViewModel>(Configuration)
                .SingleOrDefaultAsync(pdt => pdt.Id == id);
        }
    }
}
