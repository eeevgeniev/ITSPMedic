using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class REALBuilder : DataValueBuilder, IREALBuilder
    {
        private REAL _value;

        public REALBuilder()
        {
            _value = base.ResetValue<REAL>();
        }

        public IREALBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IREALBuilder AddValue(double value)
        {
            _value.Value = value;

            return this;
        }

        public REAL Build() => base.DeepClone<REAL>(_value);

        public IREALBuilder Clear()
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
