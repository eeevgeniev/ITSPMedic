using Medic.AppModels.CommissionAprs;
using Medic.AppModels.DispObservations;
using Medic.AppModels.InClinicProcedures;
using Medic.AppModels.Ins;
using Medic.AppModels.Outs;
using Medic.AppModels.PathProcedures;
using Medic.AppModels.Patients;
using Medic.AppModels.Plannings;
using Medic.AppModels.ProtocolDrugTherapies;
using Medic.AppModels.Transfers;
using Medic.EHR.Extracts;

namespace Medic.ModelToEHR.Contracts
{
    public interface IToEHRConverter
    {
        EhrExtract Convert(InViewModel model, string name, string systemId);

        EhrExtract Convert(OutViewModel model, string name, string systemId);

        EhrExtract Convert(PlannedViewModel model, string name, string systemId);

        EhrExtract Convert(CommissionAprViewModel model, string name, string systemId);

        EhrExtract Convert(DispObservationViewModel model, string name, string systemId);

        EhrExtract Convert(InClinicProcedureViewModel model, string name, string systemId);

        EhrExtract Convert(PathProcedureViewModel model, string name, string systemId);

        EhrExtract Convert(ProtocolDrugTherapyViewModel model, string name, string systemId);

        EhrExtract Convert(PatientViewModel model, string name, string systemId);

        EhrExtract Convert(TransferViewModel model, string name, string systemId);
    }
}
