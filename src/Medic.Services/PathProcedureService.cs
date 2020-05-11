using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.PathProcedures;
using Medic.Contexts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<PathProcedureViewModel> GetPathProcedureByIdAsync(int id)
        {
            return await MedicContext.PathProcedures
                .Include(pp => pp.Patient)
                .Include(pp => pp.PatientBranch)
                    .ThenInclude(pp => pp.HealthRegion)
                .Include(pp => pp.PatientHRegion)
                .Include(pp => pp.Sender)
                .Include(pp => pp.CeasedProcedure)
                .Include(pp => pp.CeasedClinicalPath)
                .Include(pp => pp.FirstMainDiag)
                .Include(pp => pp.SecondMainDiag)
                .Include(pp => pp.DoneNewProcedures)
                .Include(pp => pp.UsedDrug)
                    .ThenInclude(ud => ud.VersionCode)
                .Include(pp => pp.ClinicProcedures)
                .Include(pp => pp.DoneProcedures)
                    .ThenInclude(dp => dp.Doctor)
                .ProjectTo<PathProcedureViewModel>(Configuration)
                .SingleOrDefaultAsync(pp => pp.Id == id);
        }
    }
}