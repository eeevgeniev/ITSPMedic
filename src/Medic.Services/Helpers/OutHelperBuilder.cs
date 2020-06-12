using Medic.AppModels.Enums;
using Medic.AppModels.Outs;
using Medic.Entities;
using Medic.Services.Contracts;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class OutHelperBuilder : IHelperBuilder<Out>
    {
        private readonly OutSearch OutSearch;

        public OutHelperBuilder(OutSearch outSearch)
        {
            OutSearch = outSearch;
        }

        public IQueryable<Out> BuildQuery(IQueryable<Out> query)
        {
            if (query == default)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (OutSearch == default)
            {
                return query;
            }

            switch (OutSearch.Order)
            {
                case OutOrderEnum.OutDate:
                    query = OutSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(o => o.OutDate) : query.OrderByDescending(o => o.OutDate);
                    break;
                case OutOrderEnum.OutMainDiagnoseCode:
                    query = OutSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(o => o.OutMainDiagnose.PrimaryCode) : query.OrderByDescending(o => o.OutMainDiagnose.PrimaryCode);
                    break;
                default:
                    query = OutSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(o => o.Id) : query.OrderByDescending(o => o.Id);
                    break;
            }

            query = query.Take((int)OutSearch.Length);

            return query;
        }
    }
}
