using Medic.App.Models.Bases;
using Medic.AppModels.Patients;
using Medic.AppModels.Sexes;
using System.Collections.Generic;

namespace Medic.App.Models.Patients
{
    public class PatientPageIndexModel : BasePageModel
    {
        public int Count { get; set; }

        public int CurrentPage { get; set; }

        public List<PatientPreviewViewModel> Patients { get; set; }

        public PatientSearch Search { get; set; }

        public List<SexOption> Sexes { get; set; }
    }
}
