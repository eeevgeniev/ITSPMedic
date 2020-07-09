using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.RM;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IFolderBuilder : IDisposable
    {
        public IFolderBuilder AddName(Text name);

        public IFolderBuilder AddArchetypeId(string archetypeId);

        public IFolderBuilder AddRcId(II rcId);

        public IFolderBuilder AddMeaning(CV meaning);

        public IFolderBuilder AddSynthesised(bool synthesised);

        public IFolderBuilder AddPolicyIds(params II[] policyIds);

        public IFolderBuilder AddSensitivity(int sensitivity);

        public IFolderBuilder AddOrigParentRef(II origParentRef);

        public IFolderBuilder AddLinks(params Link[] links);

        public IFolderBuilder AddFeederAudit(AuditInfo feederAudit);

        public IFolderBuilder AddSubFolders(params Folder[] subFolders);

        public IFolderBuilder AddAttestations(params AttestationInfo[] attestations);

        public IFolderBuilder AddCompositions(params II[] compositions);

        Folder Build();

        IFolderBuilder Clear();
    }
}
