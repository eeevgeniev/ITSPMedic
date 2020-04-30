using Medic.App.Models.Bases;
using Medic.AppModels.Patients;

namespace Medic.App.Models.Patients
{
    public class PateintPagePatientModel : BasePageModel
    {
        public PatientViewModel Patient { get; set; }
    }
}