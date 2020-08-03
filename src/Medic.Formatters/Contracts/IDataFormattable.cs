using System.IO;
using System.Threading.Tasks;

namespace Medic.Formatters.Contracts
{
    public interface IDataFormattable
    {
        Task<Stream> FormatObject(object model, Stream stream);

        string MimeType { get; }
    }
}
