using Medic.AppModels.Outs;
using Medic.Entities;
using Medic.Services.Base;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medic.Services.Helpers
{
    public class OutWhereBuilder : DateTimeBaseHelper, IWhereBuilder<Out>
    {
        private readonly OutSearch OutSearch;

        public OutWhereBuilder(OutSearch outSearch)
        {
            OutSearch = outSearch;
        }

        public IQueryable<Out> Where(IQueryable<Out> queryable)
        {
            if (queryable == default)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            if (OutSearch == default)
            {
                return queryable;
            }

            if (!string.IsNullOrWhiteSpace(OutSearch.MainOutDiagnose))
            {
                queryable = queryable.Where(o => EF.Functions.Like(o.OutMainDiagnose.Primary.Code, OutSearch.MainOutDiagnose));
            }

            if (OutSearch.Sex != default)
            {
                queryable = queryable.Where(o => o.Patient.SexId == OutSearch.Sex);
            }

            if (OutSearch.CountOfAdditionalOutDiagnoses != default)
            {
                queryable = queryable.Where(o => o.OutDiagnoses.Count == OutSearch.CountOfAdditionalOutDiagnoses);
            }

            if (!string.IsNullOrEmpty(OutSearch.SendDiagnose))
            {
                queryable = queryable.Where(o => o.SendDiagnoses.Any(d => EF.Functions.Like(d.PrimaryCode, OutSearch.SendDiagnose)));
            }

            if (OutSearch.CountOfAdditionalSendDiagnoses != default)
            {
                int number = (int)OutSearch.CountOfAdditionalSendDiagnoses;

                queryable = queryable.Where(o => o.Diagnoses.Count == number);
            }

            if (!string.IsNullOrWhiteSpace(OutSearch.UsedDrug))
            {
                queryable = queryable.Where(o => o.UsedDrugs.Any(ud => EF.Functions.Like(ud.Code, OutSearch.UsedDrug)));
            }

            if (OutSearch.HealthRegion != default)
            {
                queryable = queryable.Where(o => o.PatientHRegionId == OutSearch.HealthRegion);
            }

            if (OutSearch.Age != default)
            {
                (DateTime startDate, DateTime endDate) = CalculateYearsBoundsByAges((int)OutSearch.Age);

                queryable = queryable.Where(o => startDate < o.Patient.BirthDate && o.Patient.BirthDate <= endDate);
            }

            if (OutSearch.Age == default && OutSearch.OlderThan != default)
            {
                queryable = queryable.Where(o => o.Patient.BirthDate <= CalculateYearBoundByAge((int)OutSearch.OlderThan));
            }

            if (OutSearch.Age == default && OutSearch.YoungerThan != default)
            {
                queryable = queryable.Where(o => o.Patient.BirthDate >= CalculateYearBoundByAge((int)OutSearch.YoungerThan));
            }

            return queryable;
        }
    }
}
