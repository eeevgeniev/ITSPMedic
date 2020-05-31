using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.PlannedProcedures;
using Medic.Contexts;
using Medic.Entities;
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

        public async Task<List<PlannedProcedurePreviewViewModel>> GetPlannedProceduresAsync(
            IWhereBuilder<PlannedProcedure> plannedProcedureBuilder, 
            IHelperBuilder<PlannedProcedure> helperBuilder, 
            int startIndex)
        {
            if (plannedProcedureBuilder == default)
            {
                throw new ArgumentNullException(nameof(plannedProcedureBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(plannedProcedureBuilder.Where(MedicContext.PlannedProcedures).Skip(startIndex))
                .ProjectTo<PlannedProcedurePreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetPlannedProceduresCountAsync(IWhereBuilder<PlannedProcedure> plannedProcedureBuilder)
        {
            if (plannedProcedureBuilder == default)
            {
                throw new ArgumentNullException(nameof(plannedProcedureBuilder));
            }
            
            return await plannedProcedureBuilder.Where(MedicContext.PlannedProcedures)
                .CountAsync(); 
        }
    }
}
