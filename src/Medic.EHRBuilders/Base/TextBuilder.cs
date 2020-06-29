using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Contracts;

namespace Medic.EHRBuilders.Base
{
    public abstract class TextBuilder : DataValueBuilder, ITextBuilder
    {
        public abstract ITextBuilder AddCharset(CS charset);

        public abstract ITextBuilder AddLanguage(CS language);

        public abstract ITextBuilder AddOriginalText(string originalText);

        public abstract ITextBuilder Clear();
    }
}
