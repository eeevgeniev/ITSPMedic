using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.InClinicProcedures;
using Medic.Contexts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class InClinicProcedureService : IInClinicProcedureService
    {
        private readonly MedicContext MedicContext;
        private readonly MapperConfiguration Configuration;

        public InClinicProcedureService(MedicContext medicContext, MapperConfiguration configuration)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<InClinicProcedureViewModel> GetInClinicProcedureAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException(nameof(id));
            }
            
            return await MedicContext.InClinicProcedures
                .ProjectTo<InClinicProcedureViewModel>(Configuration)
                .SingleOrDefaultAsync(icp => icp.Id == id);
        }
    }
}