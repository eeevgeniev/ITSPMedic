using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.Diags;
using Medic.AppModels.Transfers;
using Medic.Contexts.Contracts;
using Medic.Entities;
using Medic.Services.Base;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class TransferService : BaseServiceHelper, ITransferService
    {
        public TransferService(IMedicContext medicContext, MapperConfiguration configuration)
            : base(medicContext, configuration)
        {

        }

        public async Task<TransferViewModel> GetTrasnferAsync(int id)
        {
            if (id == default)
            {
                throw new ArgumentException(nameof(id));
            }

            return await Task.Run(() =>
            {
                Transfer transfer = this.MedicContext.Transfers
                    .Include(t => t.CPFile)
                    .ThenInclude(cp => cp.FileType)
                    .SingleOrDefault(t => t.Id == id);

                if (transfer == default)
                {
                    return default;
                }

                DiagPreviewViewModel firstMainDiag = base.GetDiag<DiagPreviewViewModel>(d => d.Id == transfer.FirstMainDiagId);
                DiagPreviewViewModel secondMainDiag = base.GetDiag<DiagPreviewViewModel>(d => d.Id == transfer.SecondMainDiagId);

                return new TransferViewModel()
                {
                    Id = transfer.Id,
                    IZYear = transfer.IZYear,
                    IZNumber = transfer.IZNumber,
                    FirstMainDiag = firstMainDiag,
                    SecondMainDiag = secondMainDiag,
                    CashPatient = transfer.CashPatient,
                    ClinicalProcedure = transfer.CashPatient,
                    ClinicalPath = transfer.ClinicalPath,
                    AmbulatoryProcedure = transfer.AmbulatoryProcedure,
                    DischargeWard = transfer.DischargeWard,
                    TransferWard = transfer.TransferWard,
                    TransferDateTime = transfer.TransferDateTime,
                    CPFile = transfer.CPFile?.FileType?.Name ?? default
                };
            });
        }

        public async Task<List<TransferPreviewViewModel>> GetTrasnfersAsync(IWhereBuilder<Transfer> transferBuilder, IHelperBuilder<Transfer> helperBuilder, int startIndex)
        {
            if (transferBuilder == default)
            {
                throw new ArgumentNullException(nameof(transferBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(transferBuilder.Where(MedicContext.Transfers).Skip(startIndex))
                .ProjectTo<TransferPreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetTrasnfersCountAsync(IWhereBuilder<Transfer> transferBuilder)
        {
            if (transferBuilder == default)
            {
                throw new ArgumentNullException(nameof(transferBuilder));
            }

            return await transferBuilder.Where(MedicContext.Transfers)
                .CountAsync();
        }
    }
}
