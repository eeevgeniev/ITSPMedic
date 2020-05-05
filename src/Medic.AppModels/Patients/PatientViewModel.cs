using Medic.AppModels.CommissionAprs;
using Medic.AppModels.DispObservations;
using Medic.AppModels.InClinicProcedures;
using Medic.AppModels.Ins;
using Medic.AppModels.Outs;
using Medic.AppModels.PathProcedures;
using Medic.AppModels.PlannedProcedures;
using Medic.AppModels.ProtocolDrugTherapies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Patients
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(IdentityNumber))]
        public string IdentityNumber { get; set; }

        [Display(Name = nameof(BirthDate))]
        public DateTime BirthDate { get; set; }

        [Display(Name = nameof(FirstName))]
        public string FirstName { get; set; }

        [Display(Name = nameof(SecondName))]
        public string SecondName { get; set; }

        [Display(Name = nameof(LastName))]
        public string LastName { get; set; }

        [Display(Name = nameof(Sex))]
        public string Sex { get; set; }

        [Display(Name = nameof(Address))]
        public string Address { get; set; }

        [Display(Name = nameof(Notes))]
        public string Notes { get; set; }

        public ICollection<PatientInPreviewViewModel> Ins { get; set; }

        public ICollection<PatientInClinicProcedurePreviewViewModel> InClinicProcedures { get; set; }

        public ICollection<PatientOutPreviewViewModel> Outs { get; set; }

        public ICollection<PatientPathProcedurePreviewViewModel> PathProcedures { get; set; }

        public ICollection<PatientProtocolDrugTherapyPreviewViewModel> ProtocolDrugTherapies { get; set; }

        public ICollection<PatientCommissionAprPreviewViewModel> CommissionAprs { get; set; }

        public ICollection<PatientDispObservationPreviewViewModel> DispObservations { get; set; }

        public ICollection<PatientPlannedProcedurePreviewViewModel> PlannedProcedures { get; set; }
    }
}