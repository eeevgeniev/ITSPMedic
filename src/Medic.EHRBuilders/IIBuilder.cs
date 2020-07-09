using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class IIBuilder : DataValueBuilder, IIIBuilder
    {
        private II _value;

        public IIBuilder()
        {
            Clear();
        }
        
        public IIIBuilder AddAssigningAuthorityName(string assigningAuthorityName)
        {
            _value.AssigningAuthorityName = assigningAuthorityName;

            return this;
        }

        public IIIBuilder AddExtension(string extension)
        {
            _value.Extension = extension;

            return this;
        }

        public IIIBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IIIBuilder AddRoot(OID root)
        {
            _value.Root = root;

            return this;
        }

        public IIIBuilder AddValidTime(IVLTS validTime)
        {
            _value.ValidTime = validTime;

            return this;
        }

        public II Build() => base.DeepClone<II>(_value);

        public IIIBuilder Clear()
        {
            _value = base.ResetValue<II>();

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
