using Medic.AppModels.Enums;
using Medic.AppModels.Transfers;
using Medic.Entities;
using Medic.Services.Contracts;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class TransferHelperBuilder : IHelperBuilder<Transfer>
    {
        private readonly TransferSearch TransferSearch;

        public TransferHelperBuilder(TransferSearch transferSearch)
        {
            TransferSearch = transferSearch;
        }

        public IQueryable<Transfer> BuildQuery(IQueryable<Transfer> query)
        {
            if (query == default)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (TransferSearch == default)
            {
                return query;
            }

            switch (TransferSearch.Order)
            {
                case TransferOrderEnum.FirstMainDiagCode:
                    query = TransferSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(t => t.FirstMainDiag.MKBCode) : query.OrderByDescending(t => t.FirstMainDiag.MKBCode);
                    break;
                case TransferOrderEnum.SecondMainDiagCode:
                    query = TransferSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(t => t.SecondMainDiag.MKBCode) : query.OrderByDescending(t => t.SecondMainDiag.MKBCode);
                    break;
                default:
                    query = TransferSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(t => t.TransferDateTime) : query.OrderByDescending(t => t.TransferDateTime);
                    break;
            }

            query = query.Take((int)TransferSearch.Length);

            return query;
        }
    }
}
