using System.Threading.Tasks;

namespace Medic.Formatters.Contracts
{
    public interface IDataFormattable
    {
        Task<string> FormatObject(object model);

        string MimeType { get; }
    }
}
