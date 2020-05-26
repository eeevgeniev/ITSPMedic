using Medic.AppModels.Ins;
using Medic.Entities;
using Medic.Services.Base;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class InWhereBuilder : DateTimeBaseHelper, IWhereBuilder<In>
    {
        private readonly InsSearch InsSearch;

        public InWhereBuilder(InsSearch insSearch)
        {
            InsSearch = insSearch;
        }

        public IQueryable<In> Where(IQueryable<In> queryable)
        {
            if (queryable == default)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            if (InsSearch == default)
            {
                return queryable;
            }

            if (!string.IsNullOrEmpty(InsSearch.MainDiagnose))
            {
                queryable = queryable.Where(i => EF.Functions.Like(i.SendDiagnose.Primary.Code, InsSearch.MainDiagnose));
            }

            if (InsSearch.Sex != default)
            {
                int sex = (int)InsSearch.Sex;

                queryable = queryable.Where(i => i.Patient.Sex.Id == sex);
            }

            if (InsSearch.CountOfAdditionalDiagnoses != default)
            {
                int number = (int)InsSearch.CountOfAdditionalDiagnoses;

                queryable = queryable.Where(i => i.Diagnoses.Count == number);
            }

            if (InsSearch.HealthRegion != default)
            {
                queryable = queryable.Where(i => i.PatientHRegionId == InsSearch.HealthRegion);
            }

            if (InsSearch.Age != default)
            {
                (DateTime startDate, DateTime endDate) = CalculateYearsBoundsByAges((int)InsSearch.Age);

                queryable = queryable.Where(i => startDate < i.Patient.BirthDate && i.Patient.BirthDate <= endDate);
            }

            if (InsSearch.Age == default && InsSearch.OlderThan != default)
            {
                queryable = queryable.Where(i => i.Patient.BirthDate <= CalculateYearBoundByAge((int)InsSearch.OlderThan));
            }

            if (InsSearch.Age == default && InsSearch.YoungerThan != default)
            {
                queryable = queryable.Where(i => i.Patient.BirthDate >= CalculateYearBoundByAge((int)InsSearch.YoungerThan));
            }

            return queryable;
        }
    }
}
