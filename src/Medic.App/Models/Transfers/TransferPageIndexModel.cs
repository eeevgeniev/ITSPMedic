using Medic.App.Models.Bases;
using Medic.AppModels.Transfers;
using System.Collections.Generic;

namespace Medic.App.Models.Transfers
{
    public class TransferPageIndexModel : BasePageSummaryModel
    {
        public TransferSearch Search { get; set; }

        public List<TransferPreviewViewModel> Transfers { get; set; }
    }
}
