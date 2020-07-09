using Medic.EHR.DataTypes;
using Medic.EHR.RM;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class AuditInfoBuilder : DataValueBuilder, IAuditInfoBuilder
    {
        private AuditInfo _value;

        public AuditInfoBuilder()
        {
            Clear();
        }

        public IAuditInfoBuilder AddCommitter(II committer)
        {
            _value.Committer = committer;

            return this;
        }

        public IAuditInfoBuilder AddEhrSystem(II ehrSystem)
        {
            _value.EhrSystem = ehrSystem;

            return this;
        }

        public IAuditInfoBuilder AddReasonForRevision(CV reasonForRevision)
        {
            _value.ReasonForRevision = reasonForRevision;

            return this;
        }

        public IAuditInfoBuilder AddPreviousVersion(II previousVersion)
        {
            _value.PreviousVersion = previousVersion;

            return this;
        }

        public IAuditInfoBuilder AddTimeCommitted(TS timeCommitted)
        {
            _value.TimeCommitted = timeCommitted;

            return this;
        }

        public IAuditInfoBuilder AddVersionSetId(II versionSetId)
        {
            _value.VersionSetId = versionSetId;

            return this;
        }

        public IAuditInfoBuilder AddVersionStatus(CS versionStatus)
        {
            _value.VersionStatus = versionStatus;

            return this;
        }

        public AuditInfo Build() => base.DeepClone<AuditInfo>(_value);

        public IAuditInfoBuilder Clear()
        {
            _value = base.ResetValue<AuditInfo>();

            return this;
        }

        public override void Dispose()
        {
            if (!base._isDisposed)
            {
                _value = null;
                GC.SuppressFinalize(this);
                base._isDisposed = !base._isDisposed;
            }
        }
    }
}
