using Medic.AppModels.CommissionAprs;
using Medic.AppModels.ProtocolDrugTherapies;
using Medic.Entities;
using Medic.Services.Base;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class CommissionAprWhereBuilder : DateTimeBaseHelper, IWhereBuilder<CommissionApr>
    {
        private readonly CommissionAprSearch CommissionAprSearch;

        public CommissionAprWhereBuilder(CommissionAprSearch commissionAprSearch)
        {
            CommissionAprSearch = commissionAprSearch;
        }

        public IQueryable<CommissionApr> Where(IQueryable<CommissionApr> queryable)
        {
            if (queryable == default)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            if (CommissionAprSearch == default)
            {
                return queryable;
            }

            if (!string.IsNullOrWhiteSpace(CommissionAprSearch.MainDiagCode))
            {
                queryable = queryable.Where(ca => EF.Functions.Like(ca.MainDiag.MKBCode, CommissionAprSearch.MainDiagCode));
            }

            if (CommissionAprSearch.Sex != default)
            {
                int sex = (int)CommissionAprSearch.Sex;

                queryable = queryable.Where(ca => ca.Patient.Sex.Id == sex);
            }

            if (CommissionAprSearch.HealthRegion != default)
            {
                int healthRegion = (int)CommissionAprSearch.HealthRegion;

                queryable = queryable.Where(pdt => pdt.PatientHRegionId == healthRegion);
            }

            if (CommissionAprSearch.Age != default)
            {
                (DateTime startDate, DateTime endDate) = CalculateYearsBoundsByAges((int)CommissionAprSearch.Age);

                queryable = queryable.Where(ca => startDate < ca.Patient.BirthDate && ca.Patient.BirthDate <= endDate);
            }

            if (CommissionAprSearch.Age == default && CommissionAprSearch.OlderThan != default)
            {
                queryable = queryable.Where(ca => ca.Patient.BirthDate <= CalculateYearBoundByAge((int)CommissionAprSearch.OlderThan));
            }

            if (CommissionAprSearch.Age == default && CommissionAprSearch.YoungerThan != default)
            {
                queryable = queryable.Where(ca => ca.Patient.BirthDate >= CalculateYearBoundByAge((int)CommissionAprSearch.YoungerThan));
            }

            return queryable;
        }
    }
}
