using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class SimpleTextBuilder : DataValueBuilder, ISimpleTextBuilder
    {
        private SimpleText _value;

        public SimpleTextBuilder()
        {
            Clear();
        }
        
        public ISimpleTextBuilder AddCharset(CS charset)
        {
            _value.Charset = charset;

            return this;
        }

        public ISimpleTextBuilder AddLanguage(CS language)
        {
            _value.Language = language;

            return this;
        }

        public ISimpleTextBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public ISimpleTextBuilder AddOriginalText(string originalText)
        {
            _value.OriginalText = originalText;

            return this;
        }

        public SimpleText Build() => base.DeepClone<SimpleText>(_value);

        public ISimpleTextBuilder Clear()
        {
            _value = base.ResetValue<SimpleText>();

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
