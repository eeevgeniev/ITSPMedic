using Medic.AppModels.DispObservations;
using Medic.Entities;
using Medic.Services.Base;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class DispObservationWhereBuilder : DateTimeBaseHelper, IWhereBuilder<DispObservation>
    {
        private readonly DispObservationSearch DispObservationSearch;

        public DispObservationWhereBuilder(DispObservationSearch dispObservationSearch)
        {
            DispObservationSearch = dispObservationSearch;
        }

        public IQueryable<DispObservation> Where(IQueryable<DispObservation> queryable)
        {
            if (queryable == default)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            if (DispObservationSearch == default)
            {
                return queryable;
            }

            if (!string.IsNullOrWhiteSpace(DispObservationSearch.FirstMainDiagCode))
            {
                queryable = queryable.Where(disp => EF.Functions.Like(disp.FirstMainDiag.MKBCode, DispObservationSearch.FirstMainDiagCode));
            }

            if (!string.IsNullOrWhiteSpace(DispObservationSearch.SecondMainDiagCode))
            {
                queryable = queryable.Where(disp => EF.Functions.Like(disp.SecondMainDiag.MKBCode, DispObservationSearch.SecondMainDiagCode));
            }

            if (DispObservationSearch.Sex != default)
            {
                int sex = (int)DispObservationSearch.Sex;

                queryable = queryable.Where(disp => disp.Patient.Sex.Id == sex);
            }

            if (DispObservationSearch.HealthRegion != default)
            {
                int healthRegion = (int)DispObservationSearch.HealthRegion;

                queryable = queryable.Where(disp => disp.PatientHRegionId == healthRegion);
            }

            if (DispObservationSearch.Age != default)
            {
                (DateTime startDate, DateTime endDate) = CalculateYearsBoundsByAges((int)DispObservationSearch.Age);

                queryable = queryable.Where(disp => startDate < disp.Patient.BirthDate && disp.Patient.BirthDate <= endDate);
            }

            if (DispObservationSearch.Age == default && DispObservationSearch.OlderThan != default)
            {
                queryable = queryable.Where(disp => disp.Patient.BirthDate <= CalculateYearBoundByAge((int)DispObservationSearch.OlderThan));
            }

            if (DispObservationSearch.Age == default && DispObservationSearch.YoungerThan != default)
            {
                queryable = queryable.Where(disp => disp.Patient.BirthDate >= CalculateYearBoundByAge((int)DispObservationSearch.YoungerThan));
            }

            return queryable;
        }
    }
}
