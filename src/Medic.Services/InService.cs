using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.Ins;
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
    public class InService : IInService
    {
        private readonly MedicContext MedicContext;
        private readonly MapperConfiguration Configuration;

        public InService(MedicContext medicContext, MapperConfiguration configuration)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<InViewModel> GetInAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            return await MedicContext.Ins
                .Include(i => i.Patient)
                .Include(i => i.PatientBranch)
                .Include(i => i.PatientHRegion)
                .Include(i => i.Sender)
                .Include(i => i.SendDiagnose)
                .Include(i => i.Diagnoses)
                .Include(i => i.CPFile)
                .ProjectTo<InViewModel>(Configuration)
                .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<InPreviewViewModel>> GetInsAsync(InsSerach search, int startIndex, int count)
        {
            return await GetQueryable(MedicContext.Ins, search)
                .Include(i => i.SendDiagnose)
                    .ThenInclude(sd => sd.Primary)
                .Include(i => i.Patient)
                .Include(i => i.Diagnoses)
                    .ThenInclude(d => d.Primary)
                .ProjectTo<InPreviewViewModel>(Configuration)
                .Skip(startIndex)
                .Take(count)
                .ToListAsync();
        }

        public async Task<int> GetInsCountAsync(InsSerach search)
        {
            return await GetQueryable(MedicContext.Ins, search)
                .CountAsync();
        }

        private IQueryable<In> GetQueryable(IQueryable<In> insQuery, InsSerach search)
        {
            if (search != default)
            {
                DateTimeHelper dateTimeHelper = new DateTimeHelper();
                
                if (!string.IsNullOrEmpty(search.MainDiagnose))
                {
                    insQuery = insQuery.Where(i => EF.Functions.Like(i.SendDiagnose.Primary.Code, search.MainDiagnose));
                }

                if (search.Sex != default)
                {
                    int sex = (int)search.Sex;

                    insQuery = insQuery.Where(i => i.Patient.Sex.Id == sex);
                }

                if (search.NumberOfAdditionalDiagnoses != default)
                {
                    int number = (int)search.NumberOfAdditionalDiagnoses;

                    insQuery = insQuery.Where(i => i.Diagnoses.Count == number);
                }

                if (search.Diagnoses != default && search.Diagnoses.Count > 0)
                {
                    insQuery = insQuery.Where(i => i.Diagnoses.Any(d => search.Diagnoses.Contains(d.Primary.Code)));
                }

                if (search.Age != default)
                {
                    (DateTime startDate, DateTime endDate) = dateTimeHelper.CalculateYearsBoundsByAges((int)search.Age);

                    insQuery = insQuery.Where(i => startDate < i.Patient.BirthDate && i.Patient.BirthDate <= endDate);
                }

                if (search.Age == default && search.OlderThan != default)
                {
                    insQuery = insQuery.Where(i => i.Patient.BirthDate <= dateTimeHelper.CalculateYearBoundByAge((int)search.OlderThan));
                }

                if (search.Age == default && search.YoungerThan != default)
                {
                    insQuery = insQuery.Where(i => i.Patient.BirthDate >= dateTimeHelper.CalculateYearBoundByAge((int)search.YoungerThan));
                }
            }

            return insQuery;
        }
    }
}
