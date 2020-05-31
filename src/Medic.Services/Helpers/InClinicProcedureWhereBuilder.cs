using Medic.AppModels.InClinicProcedures;
using Medic.Entities;
using Medic.Services.Base;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class InClinicProcedureWhereBuilder : DateTimeBaseHelper, IWhereBuilder<InClinicProcedure>
    {
        private readonly InClinicProcedureSearch InClinicProcedureSearch;

        public InClinicProcedureWhereBuilder(InClinicProcedureSearch inClinicProcedureSearch)
        {
            InClinicProcedureSearch = inClinicProcedureSearch;
        }

        public IQueryable<InClinicProcedure> Where(IQueryable<InClinicProcedure> queryable)
        {
            if (queryable == default)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            if (InClinicProcedureSearch == default)
            {
                return queryable;
            }

            if (!string.IsNullOrWhiteSpace(InClinicProcedureSearch.FirstMainDiagCode))
            {
                queryable = queryable.Where(icp => EF.Functions.Like(icp.FirstMainDiag.MKBCode, InClinicProcedureSearch.FirstMainDiagCode));
            }

            if (!string.IsNullOrWhiteSpace(InClinicProcedureSearch.SecondMainDiagCode))
            {
                queryable = queryable.Where(icp => EF.Functions.Like(icp.SecondMainDiag.MKBCode, InClinicProcedureSearch.SecondMainDiagCode));
            }

            if (InClinicProcedureSearch.Sex != default)
            {
                int sex = (int)InClinicProcedureSearch.Sex;

                queryable = queryable.Where(pdt => pdt.Patient.Sex.Id == sex);
            }

            if (InClinicProcedureSearch.HealthRegion != default)
            {
                int healthRegion = (int)InClinicProcedureSearch.HealthRegion;

                queryable = queryable.Where(icp => icp.PatientHealthRegionId == healthRegion);
            }

            if (InClinicProcedureSearch.Age != default)
            {
                (DateTime startDate, DateTime endDate) = CalculateYearsBoundsByAges((int)InClinicProcedureSearch.Age);

                queryable = queryable.Where(icp => startDate < icp.Patient.BirthDate && icp.Patient.BirthDate <= endDate);
            }

            if (InClinicProcedureSearch.Age == default && InClinicProcedureSearch.OlderThan != default)
            {
                queryable = queryable.Where(icp => icp.Patient.BirthDate <= CalculateYearBoundByAge((int)InClinicProcedureSearch.OlderThan));
            }

            if (InClinicProcedureSearch.Age == default && InClinicProcedureSearch.YoungerThan != default)
            {
                queryable = queryable.Where(icp => icp.Patient.BirthDate >= CalculateYearBoundByAge((int)InClinicProcedureSearch.YoungerThan));
            }

            return queryable;
        }
    }
}
