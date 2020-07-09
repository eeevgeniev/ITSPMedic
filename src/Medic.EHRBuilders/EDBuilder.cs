using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class EDBuilder : DataValueBuilder, IEDBuilder
    {
        private ED _value;

        public EDBuilder()
        {
            _value = base.ResetValue<ED>();
        }

        public IEDBuilder AddAlternateString(SimpleText simpleText)
        {
            throw new NotImplementedException();
        }

        public IEDBuilder AddCharset(CS cs)
        {
            _value.Charset = cs;

            return this;
        }

        public IEDBuilder AddCompression(CS cs)
        {
            _value.Compression = cs;

            return this;
        }

        public IEDBuilder AddData(string data)
        {
            _value.Data = data;

            return this;
        }

        public IEDBuilder AddIntegrityCheck(string integrityCheck)
        {
            _value.IntegrityCheck = integrityCheck;

            return this;
        }

        public IEDBuilder AddIntegrityCheckAlgorithm(CS cs)
        {
            _value.IntegrityCheckAlgorithm = cs;

            return this;
        }

        public IEDBuilder AddLanguage(CS cs)
        {
            _value.Language = cs;

            return this;
        }

        public IEDBuilder AddMediaType(CS cs)
        {
            _value.MediaType = cs;

            return this;
        }

        public IEDBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IEDBuilder AddReference(URI uri)
        {
            _value.Reference = uri;

            return this;
        }

        public IEDBuilder AddSize(int size)
        {
            _value.Size = size;

            return this;
        }

        public IEDBuilder AddThumbnail(ED ed)
        {
            _value.Thumbnail = ed;

            return this;
        }

        public ED Build() => base.DeepClone<ED>(_value);

        public IEDBuilder Clear()
        {
            _value = base.ResetValue<ED>();

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
