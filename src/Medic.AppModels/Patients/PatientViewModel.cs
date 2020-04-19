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

namespace Medic.AppModels.Patients
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        public string IdentityNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string Sex { get; set; }

        public string Address { get; set; }

        public string Notes { get; set; }

        public ICollection<PatientInPreviewViewModel> Ins { get; set; } = new HashSet<PatientInPreviewViewModel>();

        public ICollection<PatientInClinicProcedurePreviewViewModel> InClinicProcedures { get; set; } = new HashSet<PatientInClinicProcedurePreviewViewModel>();

        public ICollection<PatientOutPreviewViewModel> Outs { get; set; } = new HashSet<PatientOutPreviewViewModel>();

        public ICollection<PatientPathProcedurePreviewViewModel> PathProcedures { get; set; } = new HashSet<PatientPathProcedurePreviewViewModel>();

        public ICollection<PatientProtocolDrugTherapyPreviewViewModel> ProtocolDrugTherapies { get; set; } = new HashSet<PatientProtocolDrugTherapyPreviewViewModel>();

        public ICollection<PatientCommissionAprPreviewViewModel> CommissionAprs { get; set; } = new HashSet<PatientCommissionAprPreviewViewModel>();

        public ICollection<PatientDispObservationPreviewViewModel> DispObservations { get; set; } = new HashSet<PatientDispObservationPreviewViewModel>();

        public ICollection<PatientPlannedProcedurePreviewViewModel> PlannedProcedures { get; set; } = new HashSet<PatientPlannedProcedurePreviewViewModel>();
    }
}