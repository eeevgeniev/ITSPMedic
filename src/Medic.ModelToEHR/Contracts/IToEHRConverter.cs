using Medic.AppModels.CommissionAprs;
using Medic.AppModels.DispObservations;
using Medic.AppModels.InClinicProcedures;
using Medic.AppModels.Ins;
using Medic.AppModels.Outs;
using Medic.AppModels.PathProcedures;
using Medic.AppModels.Patients;
using Medic.AppModels.Plannings;
using Medic.AppModels.ProtocolDrugTherapies;
using Medic.EHR.RM;

namespace Medic.ModelToEHR.Contracts
{
    public interface IToEHRConverter
    {
        ReferenceModel Convert(InViewModel model, string name);

        ReferenceModel Convert(OutViewModel model, string name);

        ReferenceModel Convert(PlannedViewModel model, string name);

        ReferenceModel Convert(CommissionAprViewModel model, string name);

        ReferenceModel Convert(DispObservationViewModel model, string name);

        ReferenceModel Convert(InClinicProcedureViewModel model, string name);

        ReferenceModel Convert(PathProcedureViewModel model, string name);

        ReferenceModel Convert(ProtocolDrugTherapyViewModel model, string name);

        ReferenceModel Convert(PatientViewModel model, string name);
    }
}
