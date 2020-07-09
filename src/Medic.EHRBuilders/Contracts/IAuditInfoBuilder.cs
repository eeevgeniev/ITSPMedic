using Medic.EHR.DataTypes;
using Medic.EHR.RM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.EHRBuilders.Contracts
{
    public interface IAuditInfoBuilder : IDisposable
    {
        public IAuditInfoBuilder AddEhrSystem(II ehrSystem);

        public IAuditInfoBuilder AddTimeCommitted(TS timeCommitted);

        public IAuditInfoBuilder AddCommitter(II committer);

        public IAuditInfoBuilder AddVersionStatus(CS versionStatus);

        public IAuditInfoBuilder AddReasonForRevision(CV reasonForRevision);

        public IAuditInfoBuilder AddPreviousVersion(II previousVersion);

        public IAuditInfoBuilder AddVersionSetId(II versionSetId);

        AuditInfo Build();

        IAuditInfoBuilder Clear();
    }
}
