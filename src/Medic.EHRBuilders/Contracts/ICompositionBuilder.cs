using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.RM;
using Medic.EHR.RM.Base;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface ICompositionBuilder : IDisposable
    {
        public ICompositionBuilder AddName(Text name);

        public ICompositionBuilder AddArchetypeId(string archetypeId);

        public ICompositionBuilder AddRcId(II rcId);

        public ICompositionBuilder AddMeaning(CV meaning);

        public ICompositionBuilder AddSynthesised(bool synthesised);

        public ICompositionBuilder AddPolicyIds(params II[] policyIds);

        public ICompositionBuilder AddSensitivity(int sensitivity);

        public ICompositionBuilder AddOrigParentRef(II origParentRef);

        public ICompositionBuilder AddLinks(params Link[] links);

        public ICompositionBuilder AddFeederAudit(AuditInfo feederAudit);

        public ICompositionBuilder AddSessionTime(IVLTS sessionTime);

        public ICompositionBuilder AddTerritory(CS territory);

        public ICompositionBuilder AddContributionId(II contributionId);

        public ICompositionBuilder AddCommittal(AuditInfo committal);

        public ICompositionBuilder AddComposer(FunctionalRole composer);

        public ICompositionBuilder AddOtherParticipation(params FunctionalRole[] otherParticipation);

        public ICompositionBuilder AddAttestations(params AttestationInfo[] attestations);

        public ICompositionBuilder AddContent(params Content[] content);

        Composition Build();

        ICompositionBuilder Clear();
    }
}
