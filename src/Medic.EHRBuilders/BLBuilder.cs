using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class BLBuilder : DataValueBuilder, IValueBuilder<bool>
    {
        private BL _value;

        public BLBuilder()
        {
            _value = base.ResetValue<BL>();
        }

        public override IDataValueBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IValueBuilder<bool> AddValue(bool value)
        {
            _value.Value = value;

            return this;
        }

        public override DataValue Build() => base.DeepCopy<BL>(_value);

        public IValueBuilder<bool> Clear()
        {
            _value = base.ResetValue<BL>();

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
