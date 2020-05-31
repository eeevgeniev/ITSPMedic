using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.PathProcedures;
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
    public class PathProcedureService : IPathProcedureService
    {
        private readonly MedicContext MedicContext;
        private readonly MapperConfiguration Configuration;

        public PathProcedureService(MedicContext medicContext, MapperConfiguration configuration)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<List<PathProcedurePreviewViewModel>> GetPathProceduresAsync(
            IWhereBuilder<PathProcedure> pathProcedureBuilder, 
            IHelperBuilder<PathProcedure> helperBuilder, 
            int startIndex)
        {
            if (pathProcedureBuilder == default)
            {
                throw new ArgumentNullException(nameof(pathProcedureBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(pathProcedureBuilder.Where(MedicContext.PathProcedures).Skip(startIndex))
                .ProjectTo<PathProcedurePreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetPathProceduresCountAsync(IWhereBuilder<PathProcedure> pathProcedureBuilder)
        {
            if (pathProcedureBuilder == default)
            {
                throw new ArgumentNullException(nameof(pathProcedureBuilder));
            }

            return await pathProcedureBuilder.Where(MedicContext.PathProcedures)
                .CountAsync();
        }

        public async Task<PathProcedureViewModel> GetPathProcedureByIdAsync(int id)
        {
            return await MedicContext.PathProcedures
                .ProjectTo<PathProcedureViewModel>(Configuration)
                .SingleOrDefaultAsync(pp => pp.Id == id);
        }
    }
}