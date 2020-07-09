using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.RM;
using Medic.EHR.RM.Base;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface ISectionBuilder : IDisposable
    {
        public ISectionBuilder AddName(Text name);

        public ISectionBuilder AddArchetypeId(string archetypeId);

        public ISectionBuilder AddRcId(II rcId);

        public ISectionBuilder AddMeaning(CV meaning);

        public ISectionBuilder AddSynthesised(bool synthesised);

        public ISectionBuilder AddPolicyIds(params II[] policyIds);

        public ISectionBuilder AddSensitivity(int sensitivity);

        public ISectionBuilder AddOrigParentRef(II origParentRef);

        public ISectionBuilder AddLinks(params Link[] links);

        public ISectionBuilder AddFeederAudit(AuditInfo feederAudit);

        public ISectionBuilder AddMembers(params Content[] members);

        Section Build();

        ISectionBuilder Clear();
    }
}
