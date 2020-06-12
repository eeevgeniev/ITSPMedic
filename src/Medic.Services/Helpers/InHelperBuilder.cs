using Medic.AppModels.Enums;
using Medic.AppModels.Ins;
using Medic.Entities;
using Medic.Services.Contracts;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class InHelperBuilder : IHelperBuilder<In>
    {
        private readonly InsSearch InsSearch;

        public InHelperBuilder(InsSearch insSearch)
        {
            InsSearch = insSearch;
        }
        
        public IQueryable<In> BuildQuery(IQueryable<In> query)
        {
            if (query == default)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (InsSearch == default)
            {
                return query;
            }

            switch (InsSearch.Order)
            {
                case InOrderEnum.EntryDate:
                    query = InsSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(i => i.SendDate) : query.OrderByDescending(i => i.SendDate);
                    break;
                default:
                    query = InsSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(i => i.Id) : query.OrderByDescending(i => i.Id);
                    break;
            }

            query = query.Take((int)InsSearch.Length);

            return query;
        }
    }
}
