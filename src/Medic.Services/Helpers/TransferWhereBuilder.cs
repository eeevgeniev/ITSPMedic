using Medic.AppModels.Transfers;
using Medic.Entities;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class TransferWhereBuilder : IWhereBuilder<Transfer>
    {
        private readonly TransferSearch TransferSearch;

        public TransferWhereBuilder(TransferSearch transferSearch)
        {
            TransferSearch = transferSearch;
        }

        public IQueryable<Transfer> Where(IQueryable<Transfer> queryable)
        {
            if (queryable == default)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            if (TransferSearch == default)
            {
                return queryable;
            }

            if (!string.IsNullOrWhiteSpace(TransferSearch.FirstMainDiagCode))
            {
                queryable = queryable.Where(t => EF.Functions.Like(t.FirstMainDiag.MKBCode, TransferSearch.FirstMainDiagCode));
            }

            if (!string.IsNullOrWhiteSpace(TransferSearch.SecondMainDiagCode))
            {
                queryable = queryable.Where(t => EF.Functions.Like(t.SecondMainDiag.MKBCode, TransferSearch.SecondMainDiagCode));
            }

            return queryable;
        }
    }
}
