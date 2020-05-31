using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.InClinicProcedures;
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

        public async Task<List<InClinicProcedurePreviewViewModel>> GetInClinicProceduresAsync(
            IWhereBuilder<InClinicProcedure> inClinicProcedureBuilder, 
            IHelperBuilder<InClinicProcedure> helperBuilder, 
            int startIndex)
        {
            if (inClinicProcedureBuilder == default)
            {
                throw new ArgumentNullException(nameof(inClinicProcedureBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(inClinicProcedureBuilder.Where(MedicContext.InClinicProcedures).Skip(startIndex))
                .ProjectTo<InClinicProcedurePreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetInClinicProceduresCountAsync(IWhereBuilder<InClinicProcedure> inClinicProcedureBuilder)
        {
            if (inClinicProcedureBuilder == default)
            {
                throw new ArgumentNullException(nameof(inClinicProcedureBuilder));
            }

            return await inClinicProcedureBuilder.Where(MedicContext.InClinicProcedures)
                .CountAsync();
        }
    }
}