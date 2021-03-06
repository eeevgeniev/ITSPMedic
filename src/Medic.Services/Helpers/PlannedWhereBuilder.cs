﻿using Medic.AppModels.Plannings;
using Medic.Entities;
using Medic.Services.Base;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class PlannedWhereBuilder : DateTimeBaseHelper, IWhereBuilder<Planned>
    {
        private readonly PlannedSearch PlannedProcedureSearch;

        public PlannedWhereBuilder(PlannedSearch plannedProcedureSearch)
        {
            PlannedProcedureSearch = plannedProcedureSearch;
        }

        public IQueryable<Planned> Where(IQueryable<Planned> queryable)
        {
            if (queryable == default)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            if (PlannedProcedureSearch == default)
            {
                return queryable;
            }

            if (!string.IsNullOrWhiteSpace(PlannedProcedureSearch.SendDiagnoseCode))
            {
                queryable = queryable.Where(pp => pp.SendDiagnoses.Any(d => EF.Functions.Like(d.PrimaryCode, PlannedProcedureSearch.SendDiagnoseCode)));
            }

            if (!string.IsNullOrWhiteSpace(PlannedProcedureSearch.DiagnoseCode))
            {
                queryable = queryable.Where(pp => pp.Diagnoses.Any(d => EF.Functions.Like(d.PrimaryCode, PlannedProcedureSearch.DiagnoseCode)));
            }

            if (PlannedProcedureSearch.Sex != default)
            {
                int sex = (int)PlannedProcedureSearch.Sex;

                queryable = queryable.Where(pp => pp.Patient.Sex.Id == sex);
            }

            if (PlannedProcedureSearch.HealthRegion != default)
            {
                int healthRegion = (int)PlannedProcedureSearch.HealthRegion;

                queryable = queryable.Where(pp => pp.PatientHRegionId == healthRegion);
            }

            if (PlannedProcedureSearch.Age != default)
            {
                (DateTime startDate, DateTime endDate) = CalculateYearsBoundsByAges((int)PlannedProcedureSearch.Age);

                queryable = queryable.Where(pp => startDate < pp.Patient.BirthDate && pp.Patient.BirthDate <= endDate);
            }

            if (PlannedProcedureSearch.Age == default && PlannedProcedureSearch.OlderThan != default)
            {
                queryable = queryable.Where(pp => pp.Patient.BirthDate <= CalculateYearBoundByAge((int)PlannedProcedureSearch.OlderThan));
            }

            if (PlannedProcedureSearch.Age == default && PlannedProcedureSearch.YoungerThan != default)
            {
                queryable = queryable.Where(pp => pp.Patient.BirthDate >= CalculateYearBoundByAge((int)PlannedProcedureSearch.YoungerThan));
            }

            return queryable;
        }
    }
}
