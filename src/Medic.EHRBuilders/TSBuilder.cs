using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class TSBuilder : DataValueBuilder, ITSBuilder
    {
        private TS _value;

        public TSBuilder()
        {
            Clear();
        }
        
        public ITSBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public ITSBuilder AddTime(DateTime dateTime)
        {
            _value.Time = dateTime;

            return this;
        }

        public TS Build() => base.DeepClone<TS>(_value);

        public ITSBuilder Clear()
        {
            _value = base.ResetValue<TS>();

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
