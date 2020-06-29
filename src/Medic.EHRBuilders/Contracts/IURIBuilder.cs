namespace Medic.EHRBuilders.Contracts
{
    public interface IURIBuilder
    {
        IURIBuilder AddValue(string value);

        IURIBuilder AddScheme(string scheme);

        IURIBuilder AddPath(string path);

        IURIBuilder AddFragmentId(string fragmentId);

        IURIBuilder AddUriQuery(string uriQuery);

        IURIBuilder AddLiteral(string literal);

        IURIBuilder Clear();
    }
}
