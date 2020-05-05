using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.Outs;
using Medic.Contexts;
using Medic.Entities;
using Medic.Services.Contracts;
using Medic.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class OutService : IOutService
    {
        private readonly MedicContext MedicContext;
        private readonly MapperConfiguration Configuration;

        public OutService(MedicContext medicContext, MapperConfiguration configuration)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<OutViewModel> GetOutAsyns(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            return await MedicContext.Outs
                .Include(o => o.Patient)
                .Include(o => o.PatientBranch)
                .Include(o => o.PatientHRegion)
                .Include(o => o.Sender)
                .Include(o => o.SendDiagnose)
                .Include(o => o.Diagnoses)
                .Include(o => o.Dead)
                .Include(o => o.HistologicalResult)
                .Include(o => o.Epicrisis)
                .Include(o => o.OutMainDiagnose)
                .Include(o => o.OutDiagnoses)
                .Include(o => o.UsedDrug)
                    .ThenInclude(ud => ud.VersionCode)
                .Include(o => o.Procedures)
                    .ThenInclude(p => p.Implant)
                .ProjectTo<OutViewModel>(Configuration)
                .SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<OutPreviewViewModel>> GetOutsAsync(OutSearch search, int startIndex, int count)
        {
            return await GetQueryable(MedicContext.Outs, search)
                .Include(o => o.OutMainDiagnose)
                    .ThenInclude(md => md.Primary)
                .Include(o => o.Patient)
                .Include(o => o.OutDiagnoses)
                    .ThenInclude(od => od.Primary)
                .Include(o => o.SendDiagnose)
                    .ThenInclude(sd => sd.Primary)
                .Include(o => o.Diagnoses)
                    .ThenInclude(d => d.Primary)
                .Include(o => o.UsedDrug)
                .ProjectTo<OutPreviewViewModel>(Configuration)
                .Skip(startIndex)
                .Take(count)
                .ToListAsync();
        }

        public async Task<int> GetOutsCountAsync(OutSearch search)
        {
            return await GetQueryable(MedicContext.Outs, search)
                .CountAsync();
        }

        private IQueryable<Out> GetQueryable(IQueryable<Out> outQuery, OutSearch search)
        {
            if (search != default)
            {
                DateTimeHelper dateTimeHelper = new DateTimeHelper();
                
                if (!string.IsNullOrWhiteSpace(search.MainOutDiagnose))
                {
                    outQuery = outQuery.Where(o => EF.Functions.Like(o.OutMainDiagnose.Primary.Code, search.MainOutDiagnose));
                }

                if (search.Sex != default)
                {
                    outQuery = outQuery.Where(o => o.Patient.SexId == search.Sex);
                }

                if (search.CountOfAdditionalOutDiagnoses != default)
                {
                    outQuery = outQuery.Where(o => o.OutDiagnoses.Count == search.CountOfAdditionalOutDiagnoses);
                }

                if (!string.IsNullOrEmpty(search.SendDiagnose))
                {
                    outQuery = outQuery.Where(o => EF.Functions.Like(o.SendDiagnose.Primary.Code, search.SendDiagnose));
                }

                if (search.CountOfAdditionalDiagnoses != default)
                {
                    int number = (int)search.CountOfAdditionalDiagnoses;

                    outQuery = outQuery.Where(o => o.Diagnoses.Count == number);
                }

                if (!string.IsNullOrWhiteSpace(search.UsedDrug))
                {
                    outQuery = outQuery.Where(o => EF.Functions.Like(o.UsedDrug.Code, search.UsedDrug));
                }

                if (search.Age != default)
                {
                    (DateTime startDate, DateTime endDate) = dateTimeHelper.CalculateYearsBoundsByAges((int)search.Age);

                    outQuery = outQuery.Where(i => startDate < i.Patient.BirthDate && i.Patient.BirthDate <= endDate);
                }

                if (search.Age == default && search.OlderThan != default)
                {
                    outQuery = outQuery.Where(i => i.Patient.BirthDate <= dateTimeHelper.CalculateYearBoundByAge((int)search.OlderThan));
                }

                if (search.Age == default && search.YoungerThan != default)
                {
                    outQuery = outQuery.Where(i => i.Patient.BirthDate >= dateTimeHelper.CalculateYearBoundByAge((int)search.YoungerThan));
                }
            }

            return outQuery;
        }
    }
}
