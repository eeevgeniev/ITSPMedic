using Medic.AppModels.Patients;
using Medic.Entities;
using Medic.Services.Base;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class PatientWhereBuilder : DateTimeBaseHelper, IWhereBuilder<Patient>
    {
        private readonly PatientSearch PatientSearch;

        public PatientWhereBuilder(PatientSearch patientSearch)
        {
            PatientSearch = patientSearch;
        }

        public IQueryable<Patient> Where(IQueryable<Patient> queryable)
        {
            if (queryable == default)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            if (PatientSearch == default)
            {
                return queryable;
            }

            if (!string.IsNullOrWhiteSpace(PatientSearch.IdentityNumber))
            {
                queryable = queryable.Where(p => EF.Functions.Like(p.IdentityNumber, PatientSearch.IdentityNumber));
            }

            if (PatientSearch.Age != default)
            {
                (DateTime startDate, DateTime endDate) = CalculateYearsBoundsByAges((int)PatientSearch.Age);

                queryable = queryable.Where(p => startDate < p.BirthDate && p.BirthDate <= endDate);
            }

            if (PatientSearch.Age == default && PatientSearch.OlderThan != default)
            {
                queryable = queryable.Where(p => p.BirthDate <= CalculateYearBoundByAge((int)PatientSearch.OlderThan));
            }

            if (PatientSearch.Age == default && PatientSearch.YoungerThan != default)
            {
                queryable = queryable.Where(p => p.BirthDate >= CalculateYearBoundByAge((int)PatientSearch.YoungerThan));
            }

            if (PatientSearch.Sex != default)
            {
                int sex = (int)PatientSearch.Sex;

                queryable = queryable.Where(p => p.Sex.Id == sex);
            }

            return queryable;
        }
    }
}
