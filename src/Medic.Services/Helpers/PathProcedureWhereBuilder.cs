using Medic.AppModels.PathProcedures;
using Medic.Entities;
using Medic.Services.Base;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class PathProcedureWhereBuilder : DateTimeBaseHelper, IWhereBuilder<PathProcedure>
    {
        private readonly PathProcedureSearch PathProcedureSearch;

        public PathProcedureWhereBuilder(PathProcedureSearch pathProcedureSearch)
        {
            PathProcedureSearch = pathProcedureSearch;
        }

        public IQueryable<PathProcedure> Where(IQueryable<PathProcedure> queryable)
        {
            if (queryable == default)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            if (PathProcedureSearch == default)
            {
                return queryable;
            }

            if (!string.IsNullOrWhiteSpace(PathProcedureSearch.FirstMainDiagCode))
            {
                queryable = queryable.Where(pp => EF.Functions.Like(pp.FirstMainDiag.MKBCode, PathProcedureSearch.FirstMainDiagCode));
            }

            if (!string.IsNullOrWhiteSpace(PathProcedureSearch.SecondMainDiagCode))
            {
                queryable = queryable.Where(pp => EF.Functions.Like(pp.SecondMainDiag.MKBCode, PathProcedureSearch.SecondMainDiagCode));
            }

            if (!string.IsNullOrWhiteSpace(PathProcedureSearch.UsedDrugCode))
            {
                queryable = queryable.Where(pp => pp.UsedDrugs.Any(ud => EF.Functions.Like(ud.DrugCode, PathProcedureSearch.UsedDrugCode)));
            }

            if (PathProcedureSearch.Sex != default)
            {
                int sex = (int)PathProcedureSearch.Sex;

                queryable = queryable.Where(pp => pp.Patient.Sex.Id == sex);
            }

            if (PathProcedureSearch.HealthRegion != default)
            {
                int healthRegion = (int)PathProcedureSearch.HealthRegion;

                queryable = queryable.Where(pp => pp.PatientHRegionId == healthRegion);
            }

            if (PathProcedureSearch.Age != default)
            {
                (DateTime startDate, DateTime endDate) = CalculateYearsBoundsByAges((int)PathProcedureSearch.Age);

                queryable = queryable.Where(pp => startDate < pp.Patient.BirthDate && pp.Patient.BirthDate <= endDate);
            }

            if (PathProcedureSearch.Age == default && PathProcedureSearch.OlderThan != default)
            {
                queryable = queryable.Where(pp => pp.Patient.BirthDate <= CalculateYearBoundByAge((int)PathProcedureSearch.OlderThan));
            }

            if (PathProcedureSearch.Age == default && PathProcedureSearch.YoungerThan != default)
            {
                queryable = queryable.Where(pp => pp.Patient.BirthDate >= CalculateYearBoundByAge((int)PathProcedureSearch.YoungerThan));
            }

            return queryable;
        }
    }
}
