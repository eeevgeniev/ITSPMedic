using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Medic.Formatters.Contracts
{
    public interface IExcelFormattable
    {
        string MimeType { get; }

        Task AddSheet<T>(IEnumerable<T> model, string sheetName) where T : class;

        Stream Save();
    }
}
