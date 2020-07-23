using Medic.App.Models.Bases;
using Medic.AppModels.Patients;

namespace Medic.App.Models.Patients
{
    public class PatientPagePatientModel : BasePageModel
    {
        public PatientViewModel Patient { get; set; }
    }
}