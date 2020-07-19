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
using Medic.EHRBuilders.Contracts;
using Medic.ModelToEHR.Contracts;
using Medic.ModelToEHR.Helpers;
using System;

namespace Medic.ModelToEHR
{
    public class ToEHRConverter : IToEHRConverter
    {
        private readonly IEHRManager EhrManager;

        private InToEHRConverter _inToEHRConverter;
        private OutToEHRConverter _outToEHRConverter;
        private PlannedToEHRConverter _plannedToEHRConverter;
        private CommissionAprToEHRConverter _commissionAprToEHRConverter;
        private DispObservationToEHRConverter _dispObservationToEHRConverter;
        private InClinicProcedureToEHRConverter _inClinicProcedureToEHRConverter;
        private PathProcedureToEHRConverter _pathProcedureToEHRConverter;
        private ProtocolDrugTherapyToEHRConverter _protocolDrugTherapyToEHRConverter;
        private PatientToEHRConverter _patientToEHRConverter;

        public ToEHRConverter(IEHRManager ehrManager)
        {
            EhrManager = ehrManager ?? throw new ArgumentNullException(nameof(EhrManager));
        }

        public ReferenceModel Convert(InViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_inToEHRConverter == default)
            {
                _inToEHRConverter = new InToEHRConverter(EhrManager);
            }

            return _inToEHRConverter.Convert(model, name);
        }

        public ReferenceModel Convert(OutViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_outToEHRConverter == default)
            {
                _outToEHRConverter = new OutToEHRConverter(EhrManager);
            }

            return _outToEHRConverter.Convert(model, name);
        }

        public ReferenceModel Convert(PlannedViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_plannedToEHRConverter == default)
            {
                _plannedToEHRConverter = new PlannedToEHRConverter(EhrManager);
            }

            return _plannedToEHRConverter.Convert(model, name);
        }

        public ReferenceModel Convert(CommissionAprViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_commissionAprToEHRConverter == default)
            {
                _commissionAprToEHRConverter = new CommissionAprToEHRConverter(EhrManager);
            }

            return _commissionAprToEHRConverter.Convert(model, name);
        }

        public ReferenceModel Convert(DispObservationViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_dispObservationToEHRConverter == default)
            {
                _dispObservationToEHRConverter = new DispObservationToEHRConverter(EhrManager);
            }

            return _dispObservationToEHRConverter.Convert(model, name);
        }

        public ReferenceModel Convert(InClinicProcedureViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_inClinicProcedureToEHRConverter == default)
            {
                _inClinicProcedureToEHRConverter = new InClinicProcedureToEHRConverter(EhrManager);
            }

            return _inClinicProcedureToEHRConverter.Convert(model, name);
        }

        public ReferenceModel Convert(PathProcedureViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_pathProcedureToEHRConverter == default)
            {
                _pathProcedureToEHRConverter = new PathProcedureToEHRConverter(EhrManager);
            }

            return _pathProcedureToEHRConverter.Convert(model, name);
        }

        public ReferenceModel Convert(ProtocolDrugTherapyViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_protocolDrugTherapyToEHRConverter == default)
            {
                _protocolDrugTherapyToEHRConverter = new ProtocolDrugTherapyToEHRConverter(EhrManager);
            }

            return _protocolDrugTherapyToEHRConverter.Convert(model, name);
        }

        public ReferenceModel Convert(PatientViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_patientToEHRConverter == default)
            {
                _patientToEHRConverter = new PatientToEHRConverter(EhrManager);
            }

            return _patientToEHRConverter.Convert(model, name);
        }
    }
}
