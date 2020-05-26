using Medic.AppModels.Enums;
using Medic.AppModels.Patients;
using Medic.Entities;
using Medic.Services.Contracts;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class PatientHelperBuilder : IHelperBuilder<Patient>
    {
        private readonly PatientSearch PatientSearch;

        public PatientHelperBuilder(PatientSearch patientSearch)
        {
            PatientSearch = patientSearch;
        }

        public IQueryable<Patient> BuildQuery(IQueryable<Patient> query)
        {
            if (query == default)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (PatientSearch == default)
            {
                return query;
            }

            switch (PatientSearch.Order)
            {
                case PatientOrderEnum.BirthDate:
                    query = PatientSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(p => p.BirthDate) : query.OrderByDescending(p => p.BirthDate);
                    break;
                case PatientOrderEnum.IdentityNumber:
                    query = PatientSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(p => p.IdentityNumber) : query.OrderByDescending(p => p.IdentityNumber);
                    break;
                default:
                    query = PatientSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(p => p.Id) : query.OrderByDescending(p => p.Id);
                    break;
            }

            query = query.Take((int)PatientSearch.Length);

            return query;
        }
    }
}
