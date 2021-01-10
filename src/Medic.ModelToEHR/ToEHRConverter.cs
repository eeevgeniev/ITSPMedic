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
using Medic.EHRBuilders.Contracts;
using Medic.ModelToEHR.Contracts;
using Medic.ModelToEHR.Helpers;
using System;
using System.Threading;

namespace Medic.ModelToEHR
{
    public class ToEHRConverter : IToEHRConverter, IDisposable
    {
        private ReaderWriterLockSlim _locker = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        private readonly IEHRManager EhrManager;

        private bool _isDisposed = false;

        private InToEHRConverter _inToEHRConverter;
        private OutToEHRConverter _outToEHRConverter;
        private PlannedToEHRConverter _plannedToEHRConverter;
        private CommissionAprToEHRConverter _commissionAprToEHRConverter;
        private DispObservationToEHRConverter _dispObservationToEHRConverter;
        private InClinicProcedureToEHRConverter _inClinicProcedureToEHRConverter;
        private PathProcedureToEHRConverter _pathProcedureToEHRConverter;
        private ProtocolDrugTherapyToEHRConverter _protocolDrugTherapyToEHRConverter;
        private PatientToEHRConverter _patientToEHRConverter;
        private TransferToEHRConverter _transferToEHRConverter;

        public ToEHRConverter(IEHRManager ehrManager)
        {
            EhrManager = ehrManager ?? throw new ArgumentNullException(nameof(EhrManager));
        }

        public EhrExtract Convert(InViewModel model, string name, string systemId)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_inToEHRConverter == default)
            {
                _locker.EnterWriteLock();

                if (_inToEHRConverter == default)
                {
                    _inToEHRConverter = new InToEHRConverter(EhrManager);
                }

                _locker.ExitWriteLock();
            }

            return _inToEHRConverter.Convert(model, name, systemId);
        }

        public EhrExtract Convert(OutViewModel model, string name, string systemId)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_outToEHRConverter == default)
            {
                _locker.EnterWriteLock();

                if (_outToEHRConverter == default)
                {
                    _outToEHRConverter = new OutToEHRConverter(EhrManager);
                }

                _locker.ExitWriteLock();
            }

            return _outToEHRConverter.Convert(model, name, systemId);
        }

        public EhrExtract Convert(PlannedViewModel model, string name, string systemId)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_plannedToEHRConverter == default)
            {
                _locker.EnterWriteLock();

                if (_plannedToEHRConverter == default)
                {
                    _plannedToEHRConverter = new PlannedToEHRConverter(EhrManager);
                }

                _locker.ExitWriteLock();
            }

            return _plannedToEHRConverter.Convert(model, name, systemId);
        }

        public EhrExtract Convert(CommissionAprViewModel model, string name, string systemId)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_commissionAprToEHRConverter == default)
            {
                _locker.EnterWriteLock();

                if (_commissionAprToEHRConverter == default)
                {
                    _commissionAprToEHRConverter = new CommissionAprToEHRConverter(EhrManager);
                }

                _locker.ExitWriteLock();
            }

            return _commissionAprToEHRConverter.Convert(model, name, systemId);
        }

        public EhrExtract Convert(DispObservationViewModel model, string name, string systemId)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_dispObservationToEHRConverter == default)
            {
                _locker.EnterWriteLock();

                if (_dispObservationToEHRConverter == default)
                {
                    _dispObservationToEHRConverter = new DispObservationToEHRConverter(EhrManager);
                }

                _locker.ExitWriteLock();
            }

            return _dispObservationToEHRConverter.Convert(model, name, systemId);
        }

        public EhrExtract Convert(InClinicProcedureViewModel model, string name, string systemId)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_inClinicProcedureToEHRConverter == default)
            {
                _locker.EnterWriteLock();

                if (_inClinicProcedureToEHRConverter == default)
                {
                    _inClinicProcedureToEHRConverter = new InClinicProcedureToEHRConverter(EhrManager);
                }

                _locker.ExitWriteLock();
            }

            return _inClinicProcedureToEHRConverter.Convert(model, name, systemId);
        }

        public EhrExtract Convert(PathProcedureViewModel model, string name, string systemId)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_pathProcedureToEHRConverter == default)
            {
                _locker.EnterWriteLock();

                if (_pathProcedureToEHRConverter == default)
                {
                    _pathProcedureToEHRConverter = new PathProcedureToEHRConverter(EhrManager);
                }

                _locker.ExitWriteLock();
            }

            return _pathProcedureToEHRConverter.Convert(model, name, systemId);
        }

        public EhrExtract Convert(ProtocolDrugTherapyViewModel model, string name, string systemId)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_protocolDrugTherapyToEHRConverter == default)
            {
                _locker.EnterWriteLock();

                if (_protocolDrugTherapyToEHRConverter == default)
                {
                    _protocolDrugTherapyToEHRConverter = new ProtocolDrugTherapyToEHRConverter(EhrManager);
                }

                _locker.ExitWriteLock();
            }

            return _protocolDrugTherapyToEHRConverter.Convert(model, name, systemId);
        }

        public EhrExtract Convert(PatientViewModel model, string name, string systemId)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_patientToEHRConverter == default)
            {
                _locker.EnterWriteLock();

                if (_patientToEHRConverter == default)
                {
                    _patientToEHRConverter = new PatientToEHRConverter(EhrManager);
                }

                _locker.ExitWriteLock();
            }

            return _patientToEHRConverter.Convert(model, name, systemId);
        }

        public EhrExtract Convert(TransferViewModel model, string name, string systemId)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_transferToEHRConverter == default)
            {
                _locker.EnterWriteLock();

                if (_transferToEHRConverter == default)
                {
                    _transferToEHRConverter = new TransferToEHRConverter(EhrManager);
                }

                _locker.ExitWriteLock();
            }

            return _transferToEHRConverter.Convert(model, name, systemId);
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _locker.Dispose();

                _inToEHRConverter = null;
                _outToEHRConverter = null;
                _plannedToEHRConverter = null;
                _commissionAprToEHRConverter = null;
                _dispObservationToEHRConverter = null;
                _inClinicProcedureToEHRConverter = null;
                _pathProcedureToEHRConverter = null;
                _protocolDrugTherapyToEHRConverter = null;
                _patientToEHRConverter = null;

                _isDisposed = !_isDisposed;

                GC.SuppressFinalize(this);
            }
        }
    }
}
