using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class CRBuilder : DataValueBuilder, ICRBuilder
    {
        private CR _value;

        public CRBuilder()
        {
            Clear();
        }
        
        public ICRBuilder AddInverted(bool inverted)
        {
            _value.Inverted = inverted;

            return this;
        }

        public ICRBuilder AddQualCode(CV qualCode)
        {
            _value.QualCode = qualCode;

            return this;
        }

        public ICRBuilder AddRole(CV role)
        {
            _value.Role = role;

            return this;
        }

        public CR Build() => base.DeepClone<CR>(_value);

        public ICRBuilder Clear()
        {
            _value = base.ResetValue<CR>();

            return this;
        }

        public override void Dispose()
        {
            if (!base._isDisposed)
            {
                _value = null;
                GC.SuppressFinalize(this);
                _isDisposed = !base._isDisposed;
            }
        }
    }
}
