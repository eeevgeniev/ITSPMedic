using Medic.EHR.DataTypes;

namespace Medic.EHRBuilders.Contracts
{
    public interface IEDBuilder
    {
        IEDBuilder AddMediaType(CS cs);

        IEDBuilder AddCharset(CS cs);

        IEDBuilder AddLanguage(CS cs);

        IEDBuilder AddSize(int size);

        IEDBuilder AddCompression(CS cs);

        IEDBuilder AddReference(URI uri);

        IEDBuilder AddIntegrityCheck(string integrityCheck);

        IEDBuilder AddIntegrityCheckAlgorithm(CS cs);

        IEDBuilder AddThumbnail(ED ed);

        IEDBuilder AddData(string data);

        IEDBuilder AddAlternateString(SimpleText simpleText);

        IEDBuilder Clear();
    }
}
