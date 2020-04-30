using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.Ins;
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
    public class InService : IInService
    {
        private readonly MedicContext MedicContext;
        private readonly MapperConfiguration Configuration;

        public InService(MedicContext medicContext, MapperConfiguration configuration)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
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
                    int age = (int)search.Age;

                    DateTime startDate = new DateTime(DateTime.Now.Year - age, 1, 1);
                    DateTime endDate = new DateTime(DateTime.Now.Year - age, 12, 31);

                    insQuery = insQuery.Where(i => startDate <= i.Patient.BirthDate && i.Patient.BirthDate <= endDate);
                }

                if (search.Age == default && search.OlderThan != default)
                {
                    int targetYear = (int)search.OlderThan;
                    
                    DateTime targetDate = new DateTime(DateTime.Now.Year - targetYear, DateTime.Now.Month, DateTime.Now.Day);

                    insQuery = insQuery.Where(i => i.Patient.BirthDate <= targetDate);
                }

                if (search.Age == default && search.OlderThan == default && search.YoungerThan != default)
                {
                    int targetYear = (int)search.YoungerThan;

                    DateTime targetDate = new DateTime(DateTime.Now.Year - targetYear, DateTime.Now.Month, DateTime.Now.Day);

                    insQuery = insQuery.Where(i => i.Patient.BirthDate >= targetDate);
                }
            }

            return insQuery;
        }
    }
}
