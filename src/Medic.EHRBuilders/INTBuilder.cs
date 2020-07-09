using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class INTBuilder : DataValueBuilder, IINTBuilder
    {
        private INT _value;

        public INTBuilder()
        {
            _value = base.ResetValue<INT>();
        }
        
        public IINTBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IINTBuilder AddValue(int value)
        {
            _value.Value = value;

            return this;
        }

        public INT Build() => base.DeepClone<INT>(_value);

        public IINTBuilder Clear()
        {
            _value = base.ResetValue<INT>();

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
