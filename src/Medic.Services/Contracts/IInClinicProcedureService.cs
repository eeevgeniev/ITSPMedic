using Medic.AppModels.InClinicProcedures;
using Medic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IInClinicProcedureService
    {
        Task<InClinicProcedureViewModel> GetInClinicProcedureAsync(int id);

        Task<List<InClinicProcedurePreviewViewModel>> GetInClinicProceduresAsync(
            IWhereBuilder<InClinicProcedure> inClinicProcedureBuilder,
            IHelperBuilder<InClinicProcedure> helperBuilder,
            int startIndex);

        Task<int> GetInClinicProceduresCountAsync(IWhereBuilder<InClinicProcedure> inClinicProcedureBuilder);
    }
}
