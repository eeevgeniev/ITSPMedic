using Medic.EHR.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.EHRBuilders.Contracts
{
    public interface ITextBuilder : IDataValueBuilder
    {
        ITextBuilder AddOriginalText(string originalText);

        ITextBuilder AddLanguage(CS language);

        ITextBuilder AddCharset(CS charset);

        ITextBuilder Clear();
    }
}
