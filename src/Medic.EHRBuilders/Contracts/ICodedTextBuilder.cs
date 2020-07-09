using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface ICodedTextBuilder : IDisposable
    {
        ICodedTextBuilder AddNullFlavor(CS cs);

        ICodedTextBuilder AddOriginalText(string originalText);

        ICodedTextBuilder AddLanguage(CS language);

        ICodedTextBuilder AddCharset(CS charset);

        ICodedTextBuilder AddCodedValue(CD codedValue);

        CodedText Build();

        ICodedTextBuilder Clear();
    }
}
