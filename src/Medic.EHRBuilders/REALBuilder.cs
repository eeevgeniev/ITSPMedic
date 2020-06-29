using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class REALBuilder : DataValueBuilder, IValueBuilder<double>
    {
        private REAL _value;

        public REALBuilder()
        {
            _value = base.ResetValue<REAL>();
        }

        public override IDataValueBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IValueBuilder<double> AddValue(double value)
        {
            _value.Value = value;

            return this;
        }

        public override DataValue Build() => base.DeepCopy<REAL>(_value);

        public IValueBuilder<double> Clear()
        {
            _value = base.ResetValue<REAL>();

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
