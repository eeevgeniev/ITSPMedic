using Medic.AppModels.ProtocolDrugTherapies;
using Medic.Entities;
using Medic.Services.Base;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class ProtocolDrugTherapyWhereBuilder : DateTimeBaseHelper, IWhereBuilder<ProtocolDrugTherapy>
    {
        private readonly ProtocolDrugTherapySearch ProtocolDrugTherapySearch;

        public ProtocolDrugTherapyWhereBuilder(ProtocolDrugTherapySearch protocolDrugTherapySearch)
        {
            ProtocolDrugTherapySearch = protocolDrugTherapySearch;
        }

        public IQueryable<ProtocolDrugTherapy> Where(IQueryable<ProtocolDrugTherapy> queryable)
        {
            if (queryable == default)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            if (ProtocolDrugTherapySearch == default)
            {
                return queryable;
            }

            if (!string.IsNullOrWhiteSpace(ProtocolDrugTherapySearch.DiagCode))
            {
                queryable = queryable.Where(pdt => EF.Functions.Like(pdt.Diag.MKBCode, ProtocolDrugTherapySearch.DiagCode));
            }

            if (ProtocolDrugTherapySearch.Sex != default)
            {
                int sex = (int)ProtocolDrugTherapySearch.Sex;

                queryable = queryable.Where(pdt => pdt.Patient.Sex.Id == sex);
            }

            if (ProtocolDrugTherapySearch.HealthRegion != default)
            {
                int healthRegion = (int)ProtocolDrugTherapySearch.HealthRegion;

                queryable = queryable.Where(pdt => pdt.PatientHRegionId == healthRegion);
            }

            if (!string.IsNullOrWhiteSpace(ProtocolDrugTherapySearch.ATCName))
            {
                queryable = queryable.Where(pdt => pdt.DrugProtocols.Any(dp => EF.Functions.Like(dp.ATCName, ProtocolDrugTherapySearch.ATCName)));
            }

            if (ProtocolDrugTherapySearch.Age != default)
            {
                (DateTime startDate, DateTime endDate) = CalculateYearsBoundsByAges((int)ProtocolDrugTherapySearch.Age);

                queryable = queryable.Where(pdt => startDate < pdt.Patient.BirthDate && pdt.Patient.BirthDate <= endDate);
            }

            if (ProtocolDrugTherapySearch.Age == default && ProtocolDrugTherapySearch.OlderThan != default)
            {
                queryable = queryable.Where(pdt => pdt.Patient.BirthDate <= CalculateYearBoundByAge((int)ProtocolDrugTherapySearch.OlderThan));
            }

            if (ProtocolDrugTherapySearch.Age == default && ProtocolDrugTherapySearch.YoungerThan != default)
            {
                queryable = queryable.Where(pdt => pdt.Patient.BirthDate >= CalculateYearBoundByAge((int)ProtocolDrugTherapySearch.YoungerThan));
            }

            return queryable;
        }
    }
}
