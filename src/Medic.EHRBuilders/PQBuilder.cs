using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class PQBuilder : DataValueBuilder, IPQBuilder
    {
        private PQ _value;

        public PQBuilder()
        {
            Clear();
        }
        
        public IPQBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IPQBuilder AddPrecision(int precision)
        {
            _value.Precision = precision;

            return this;
        }

        public IPQBuilder AddProperty(CD property)
        {
            _value.Property = property;

            return this;
        }

        public IPQBuilder AddUnits(CS units)
        {
            _value.Units = units;

            return this;
        }

        public IPQBuilder AddValue(double value)
        {
            _value.Value = value;

            return this;
        }

        public PQ Build() => base.DeepClone<PQ>(_value);

        public IPQBuilder Clear()
        {
            _value = base.ResetValue<PQ>();

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
