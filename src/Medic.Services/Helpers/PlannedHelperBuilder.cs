using Medic.AppModels.Enums;
using Medic.AppModels.Plannings;
using Medic.Entities;
using Medic.Services.Contracts;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class PlannedHelperBuilder : IHelperBuilder<Planned>
    {
        private readonly PlannedSearch PlannedProcedureSearch;

        public PlannedHelperBuilder(PlannedSearch plannedProcedureSearch)
        {
            PlannedProcedureSearch = plannedProcedureSearch;
        }

        public object PlannedProcedureSearchOrderEnum { get; private set; }

        public IQueryable<Planned> BuildQuery(IQueryable<Planned> query)
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
                case PlannedOrderEnum.SendDate:
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
