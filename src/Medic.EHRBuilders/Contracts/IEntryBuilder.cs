using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.RM;
using Medic.EHR.RM.Base;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IEntryBuilder : IDisposable
    {
        public IEntryBuilder AddName(Text name);

        public IEntryBuilder AddArchetypeId(string archetypeId);

        public IEntryBuilder AddRcId(II rcId);

        public IEntryBuilder AddMeaning(CV meaning);

        public IEntryBuilder AddSynthesised(bool synthesised);

        public IEntryBuilder AddPolicyIds(params II[] policyIds);

        public IEntryBuilder AddSensitivity(int sensitivity);

        public IEntryBuilder AddOrigParentRef(II origParentRef);

        public IEntryBuilder AddLinks(params Link[] links);

        public IEntryBuilder AddFeederAudit(AuditInfo feederAudit);

        public IEntryBuilder AddActId(string actId);

        public IEntryBuilder AddActStatus(CS actStatus);

        public IEntryBuilder AddUncertaintyExpressed(bool uncertaintyExpressed);

        public IEntryBuilder AddSubjectOfInformationCategory(CS subjectOfInformationCategory);

        public IEntryBuilder AddInfoProvider(FunctionalRole infoProvider);

        public IEntryBuilder AddSubjectOfInformation(RelatedParty subjectOfInformation);

        public IEntryBuilder AddOtherParticipations(params FunctionalRole[] otherParticipations);

        public IEntryBuilder AddItems(params Item[] items);

        Entry Build();

        IEntryBuilder Clear();
    }
}
