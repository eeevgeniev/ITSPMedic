using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.RM;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IRelatedPartyBuilder : IDisposable
    {
        public IRelatedPartyBuilder AddParty(II party);

        public IRelatedPartyBuilder AddRelationship(Text relationship);

        RelatedParty Build();

        IRelatedPartyBuilder Clear();
    }
}
