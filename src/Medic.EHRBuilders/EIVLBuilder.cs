using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class EIVLBuilder : DataValueBuilder, IEIVLBuilder
    {
        private EIVL _value;

        public EIVLBuilder()
        {
            Clear();
        }
        
        public IEIVLBuilder AddEvent(CD eventValue)
        {
            _value.Event = eventValue;

            return this;
        }

        public IEIVLBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IEIVLBuilder AddOffset(Duration offset)
        {
            _value.Offset = offset;

            return this;
        }

        public EIVL Build() => base.DeepClone<EIVL>(_value);

        public IEIVLBuilder Clear()
        {
            _value = base.ResetValue<EIVL>();

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
