using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class ORDBulder : DataValueBuilder, IORDBulder
    {
        private ORD _value;

        public ORDBulder()
        {
            Clear();
        }
        
        public IORDBulder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IORDBulder AddSymbol(CodedText symbol)
        {
            _value.Symbol = symbol;

            return this;
        }

        public IORDBulder AddValue(int value)
        {
            _value.Value = value;

            return this;
        }

        public ORD Build() => base.DeepClone<ORD>(_value);

        public IORDBulder Clear()
        {
            _value = base.ResetValue<ORD>();

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
