using Medic.AppModels.Ins;
using Medic.EHR.RM;

namespace Medic.ModelToEHR.Contracts
{
    public interface IToEHRConverter
    {
        ReferenceModel Convert(InViewModel model);
    }
}
