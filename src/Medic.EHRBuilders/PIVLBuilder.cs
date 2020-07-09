using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class PIVLBuilder : DataValueBuilder, IPIVLBuilder
    {
        private PIVL _value;

        public PIVLBuilder()
        {
            Clear();
        }

        public IPIVLBuilder AddAlignment(CD alignment)
        {
            _value.Alignment = alignment;

            return this;
        }

        public IPIVLBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IPIVLBuilder AddPeriod(Duration period)
        {
            _value.Period = period;

            return this;
        }

        public IPIVLBuilder AddPhase(IVLTS phase)
        {
            _value.Phase = phase;

            return this;
        }

        public PIVL Build() => base.DeepClone<PIVL>(_value);

        public IPIVLBuilder Clear()
        {
            _value = base.ResetValue<PIVL>();

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
