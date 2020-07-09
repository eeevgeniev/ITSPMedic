using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class RTOBuilder : DataValueBuilder, IRTOBuilder
    {
        private RTO _value;

        public RTOBuilder()
        {
            Clear();
        }

        public IRTOBuilder AddDenominator(PQ denominator)
        {
            _value.Denominator = denominator;

            return this;
        }

        public IRTOBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IRTOBuilder AddNumerator(PQ numerator)
        {
            _value.Numerator = numerator;

            return this;
        }

        public RTO Build() => base.DeepClone<RTO>(_value);

        public IRTOBuilder Clear()
        {
            _value = base.ResetValue<RTO>();

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
