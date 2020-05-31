using Medic.AppModels.Enums;
using Medic.AppModels.PlannedProcedures;
using Medic.Entities;
using Medic.Services.Contracts;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class PlannedProcedureHelperBuilder : IHelperBuilder<PlannedProcedure>
    {
        private readonly PlannedProcedureSearch PlannedProcedureSearch;

        public PlannedProcedureHelperBuilder(PlannedProcedureSearch plannedProcedureSearch)
        {
            PlannedProcedureSearch = plannedProcedureSearch;
        }

        public object PlannedProcedureSearchOrderEnum { get; private set; }

        public IQueryable<PlannedProcedure> BuildQuery(IQueryable<PlannedProcedure> query)
        {
            if (query == default)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (PlannedProcedureSearch == default)
            {
                return query;
            }

            switch (PlannedProcedureSearch.Order)
            {
                case PlannedProcedureOrderEnum.SendDiagnoseCode:
                    query = PlannedProcedureSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(pp => pp.SendDiagnose.PrimaryCode) : query.OrderByDescending(pp => pp.SendDiagnose.PrimaryCode);
                    break;
                case PlannedProcedureOrderEnum.DiagnoseCode:
                    query = PlannedProcedureSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(pp => pp.Diagnose.PrimaryCode) : query.OrderByDescending(pp => pp.Diagnose.PrimaryCode);
                    break;
                case PlannedProcedureOrderEnum.SendDate:
                    query = PlannedProcedureSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(pp => pp.SendDate) : query.OrderByDescending(pp => pp.SendDate);
                    break;
                default:
                    query = PlannedProcedureSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(pp => pp.Id) : query.OrderByDescending(pp => pp.Id);
                    break;
            }

            query = query.Take((int)PlannedProcedureSearch.Length);

            return query;
        }
    }
}
