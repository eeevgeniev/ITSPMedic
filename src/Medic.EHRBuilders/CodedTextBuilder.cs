using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class CodedTextBuilder : DataValueBuilder, ICodedTextBuilder
    {
        private CodedText _value;

        public CodedTextBuilder()
        {
            Clear();
        }
        
        public ICodedTextBuilder AddCharset(CS charset)
        {
            _value.Charset = charset;

            return this;
        }

        public ICodedTextBuilder AddCodedValue(CD codedValue)
        {
            _value.CodedValue = codedValue;

            return this;
        }

        public ICodedTextBuilder AddLanguage(CS language)
        {
            _value.Language = language;

            return this;
        }

        public ICodedTextBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public ICodedTextBuilder AddOriginalText(string originalText)
        {
            _value.OriginalText = originalText;

            return this;
        }

        public CodedText Build() => base.DeepClone<CodedText>(_value);

        public ICodedTextBuilder Clear()
        {
            _value = base.ResetValue<CodedText>();

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
