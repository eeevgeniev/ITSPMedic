using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.DispObservations;
using Medic.Contexts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
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
    }
}
