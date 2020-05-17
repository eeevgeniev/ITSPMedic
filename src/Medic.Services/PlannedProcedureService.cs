using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.PlannedProcedures;
using Medic.Contexts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class PlannedProcedureService : IPlannedProcedureService
    {
        private readonly MedicContext MedicContext;
        private readonly MapperConfiguration Configuration;

        public PlannedProcedureService(MedicContext medicContext, MapperConfiguration configuration)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<PlannedProcedureViewModel> GetPlannedProcedureAsync(int id)
        {
            return await MedicContext.PlannedProcedures
                .ProjectTo<PlannedProcedureViewModel>(Configuration)
                .SingleOrDefaultAsync(pp => pp.Id == id);
        }
    }
}
