using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class BLBuilder : DataValueBuilder, IBLBuilder
    {
        private BL _value;

        public BLBuilder()
        {
            _value = base.ResetValue<BL>();
        }

        public IBLBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IBLBuilder AddValue(bool value)
        {
            _value.Value = value;

            return this;
        }

        public BL Build() => base.DeepClone<BL>(_value);

        public IBLBuilder Clear()
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
