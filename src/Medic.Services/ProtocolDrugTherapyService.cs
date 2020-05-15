using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.ProtocolDrugTherapies;
using Medic.Contexts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
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
