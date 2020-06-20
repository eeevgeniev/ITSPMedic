using Medic.AppModels.CommissionAprs;
using Medic.AppModels.DispObservations;
using Medic.AppModels.InClinicProcedures;
using Medic.AppModels.Ins;
using Medic.AppModels.Outs;
using Medic.AppModels.PathProcedures;
using Medic.AppModels.Plannings;
using Medic.AppModels.ProtocolDrugTherapies;
using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Patients
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.IdentityNumber)]
        public string IdentityNumber { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.BirthDate)]
        public DateTime BirthDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.FirstName)]
        public string FirstName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SecondName)]
        public string SecondName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.LastName)]
        public string LastName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Sex)]
        public string Sex { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Address)]
        public string Address { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Notes)]
        public string Notes { get; set; }

        public ICollection<PatientInPreviewViewModel> Ins { get; set; }

        public ICollection<PatientInClinicProcedurePreviewViewModel> InClinicProcedures { get; set; }

        public ICollection<PatientOutPreviewViewModel> Outs { get; set; }

        public ICollection<PatientPathProcedurePreviewViewModel> PathProcedures { get; set; }

        public ICollection<PatientProtocolDrugTherapyPreviewViewModel> ProtocolDrugTherapies { get; set; }

        public ICollection<PatientCommissionAprPreviewViewModel> CommissionAprs { get; set; }

        public ICollection<PatientDispObservationPreviewViewModel> DispObservations { get; set; }

        public ICollection<PatientPlannedPreviewViewModel> Plannings { get; set; }
    }
}