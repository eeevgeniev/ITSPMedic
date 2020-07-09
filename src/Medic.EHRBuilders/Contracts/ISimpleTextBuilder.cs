using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface ISimpleTextBuilder : IDisposable
    {
        ISimpleTextBuilder AddNullFlavor(CS cs);

        ISimpleTextBuilder AddOriginalText(string originalText);

        ISimpleTextBuilder AddLanguage(CS language);

        ISimpleTextBuilder AddCharset(CS charset);

        SimpleText Build();

        ISimpleTextBuilder Clear();
    }
}
