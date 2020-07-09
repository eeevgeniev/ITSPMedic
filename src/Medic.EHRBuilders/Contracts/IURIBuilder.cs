using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IURIBuilder : IDisposable
    {
        IURIBuilder AddValue(string value);

        IURIBuilder AddScheme(string scheme);

        IURIBuilder AddPath(string path);

        IURIBuilder AddFragmentId(string fragmentId);

        IURIBuilder AddUriQuery(string uriQuery);

        IURIBuilder AddLiteral(string literal);

        IURIBuilder AddNullFlavor(CS cs);

        URI Build();

        IURIBuilder Clear();
    }
}
