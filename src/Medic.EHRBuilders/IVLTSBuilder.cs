using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class IVLTSBuilder : DataValueBuilder, IIVLTSBuilder
    {
        private IVLTS _value;

        public IVLTSBuilder()
        {
            Clear();
        }

        public IIVLTSBuilder AddHigh(TS ts)
        {
            _value.High = ts;

            return this;
        }

        public IIVLTSBuilder AddLow(TS ts)
        {
            _value.Low = ts;

            return this;
        }

        public IIVLTSBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IIVLTSBuilder AddWidth(Duration duration)
        {
            _value.Width = duration;

            return this;
        }

        public IVLTS Build() => base.DeepClone<IVLTS>(_value);

        public IIVLTSBuilder Clear()
        {
            _value = base.ResetValue<IVLTS>();

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

        public IIVLTSBuilder HighClosed(bool closed)
        {
            _value.HighClosed = closed;

            return this;
        }

        public IIVLTSBuilder LowClosed(bool closed)
        {
            _value.LowClosed = closed;

            return this;
        }
    }
}
