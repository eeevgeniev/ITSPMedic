using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class IVLBuilder : DataValueBuilder, IIVLBuilder
    {
        private IVL _value;

        public IVLBuilder()
        {
            Clear();
        }
        
        public IIVLBuilder AddHigh(Quantity quantity)
        {
            _value.High = quantity;

            return this;
        }

        public IIVLBuilder AddLow(Quantity quantity)
        {
            _value.Low = quantity;

            return this;
        }

        public IIVLBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IIVLBuilder AddWidth(Quantity quantity)
        {
            _value.Width = quantity;

            return this;
        }

        public IVL Build() => base.DeepClone<IVL>(_value);

        public IIVLBuilder Clear()
        {
            _value = base.ResetValue<IVL>();

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

        public IIVLBuilder HighClosed(bool closed)
        {
            _value.HighClosed = closed;

            return this;
        }

        public IIVLBuilder LowClosed(bool closed)
        {
            _value.LowClosed = closed;

            return this;
        }
    }
}
