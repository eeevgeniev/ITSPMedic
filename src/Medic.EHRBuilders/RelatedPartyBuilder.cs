using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.RM;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.EHRBuilders
{
    public class RelatedPartyBuilder : DataValueBuilder, IRelatedPartyBuilder
    {
        private RelatedParty _value;

        public RelatedPartyBuilder()
        {
            Clear();
        }

        public IRelatedPartyBuilder AddParty(II party)
        {
            _value.Party = party;

            return this;
        }

        public IRelatedPartyBuilder AddRelationship(Text relationship)
        {
            _value.Relationship = relationship;

            return this;
        }

        public RelatedParty Build() => base.DeepClone<RelatedParty>(_value);

        public IRelatedPartyBuilder Clear()
        {
            _value = base.ResetValue<RelatedParty>();

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
