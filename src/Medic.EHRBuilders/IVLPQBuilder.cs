using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class IVLPQBuilder : DataValueBuilder, IIVLPQBuilder
    {
        private IVLPQ _value;

        public IVLPQBuilder()
        {
            Clear();
        }

        public IIVLPQBuilder AddHigh(PQ high)
        {
            _value.High = high;

            return this;
        }

        public IIVLPQBuilder AddLow(PQ low)
        {
            _value.Low = low;

            return this;
        }

        public IIVLPQBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IIVLPQBuilder AddWidth(PQ width)
        {
            _value.Width = width;

            return this;
        }

        public IVLPQ Build() => base.DeepClone<IVLPQ>(_value);

        public IIVLPQBuilder Clear()
        {
            _value = base.ResetValue<IVLPQ>();

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

        public IIVLPQBuilder HighClosed(bool closed)
        {
            _value.HighClosed = closed;

            return this;
        }

        public IIVLPQBuilder LowClosed(bool closed)
        {
            _value.LowClosed = closed;

            return this;
        }
    }
}
