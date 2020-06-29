using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class INTBuilder : DataValueBuilder, IValueBuilder<int>
    {
        private INT _value;

        public INTBuilder()
        {
            _value = base.ResetValue<INT>();
        }
        
        public override IDataValueBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IValueBuilder<int> AddValue(int value)
        {
            _value.Value = value;

            return this;
        }

        public override DataValue Build() => base.DeepCopy<INT>(_value);

        public IValueBuilder<int> Clear()
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
