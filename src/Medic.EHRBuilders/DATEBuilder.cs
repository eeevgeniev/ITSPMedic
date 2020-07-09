using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class DATEBuilder : DataValueBuilder, IDATEBuilder
    {
        private DATE _value;

        public DATEBuilder()
        {
            Clear();
        }
        
        public IDATEBuilder AddDate(DateTime dateTime)
        {
            _value.Date = dateTime;

            return this;
        }

        public IDATEBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public DATE Build() => base.DeepClone<DATE>(_value);

        public IDATEBuilder Clear()
        {
            _value = base.ResetValue<DATE>();

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
