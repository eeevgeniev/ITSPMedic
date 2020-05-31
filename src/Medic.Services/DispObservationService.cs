using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.DispObservations;
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
    public class DispObservationService : IDispObservationService
    {
        private readonly MedicContext MedicContext;
        private readonly MapperConfiguration Configuration;

        public DispObservationService(MedicContext medicContext, MapperConfiguration configuration)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<DispObservationViewModel> GetDispObservationAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }
            
            return await MedicContext.DispObservations
                .ProjectTo<DispObservationViewModel>(Configuration)
                .SingleOrDefaultAsync(disp => disp.Id == id);
        }

        public async Task<List<DispObservationPreviewViewModel>> GetDispObservationsAsync(
            IWhereBuilder<DispObservation> dispObservationBuilder, 
            IHelperBuilder<DispObservation> helperBuilder, 
            int startIndex)
        {
            if (dispObservationBuilder == default)
            {
                throw new ArgumentNullException(nameof(dispObservationBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(dispObservationBuilder.Where(MedicContext.DispObservations.Skip(startIndex)))
                .ProjectTo<DispObservationPreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetDispObservationsCountAsync(IWhereBuilder<DispObservation> dispObservationBuilder)
        {
            if (dispObservationBuilder == default)
            {
                throw new ArgumentNullException(nameof(dispObservationBuilder));
            }

            return await dispObservationBuilder.Where(MedicContext.DispObservations)
                .CountAsync();
        }
    }
}
