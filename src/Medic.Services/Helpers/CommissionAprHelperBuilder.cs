using Medic.AppModels.CommissionAprs;
using Medic.AppModels.Enums;
using Medic.Entities;
using Medic.Services.Contracts;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class CommissionAprHelperBuilder : IHelperBuilder<CommissionApr>
    {
        private readonly CommissionAprSearch CommissionAprSearch;

        public CommissionAprHelperBuilder(CommissionAprSearch commissionAprSearch)
        {
            CommissionAprSearch = commissionAprSearch;
        }

        public IQueryable<CommissionApr> BuildQuery(IQueryable<CommissionApr> query)
        {
            if (query == default)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (CommissionAprSearch == default)
            {
                return query;
            }

            switch (CommissionAprSearch.Order)
            {
                case CommissionAprOrderEnum.SendDate:
                    query = CommissionAprSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(ca => ca.SendDate) : query.OrderByDescending(ca => ca.SendDate);
                    break;
                case CommissionAprOrderEnum.MainDiagCode:
                    query = CommissionAprSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(ca => ca.MainDiag.MKBCode) : query.OrderByDescending(ca => ca.MainDiag.MKBCode);
                    break;
                default:
                    query = CommissionAprSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(ca => ca.Id) : query.OrderByDescending(ca => ca.Id);
                    break;
            }

            query = query.Take((int)CommissionAprSearch.Length);

            return query;
        }
    }
}
