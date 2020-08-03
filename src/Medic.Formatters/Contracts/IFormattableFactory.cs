using Medic.Formatters.Enums;
using System;
using System.IO;

namespace Medic.Formatters.Contracts
{
    public interface IFormattableFactory : IDisposable
    {
        IDataFormattable CreateFormatter(FormatterEnum formatter);

        IExcelFormattable CreateExcelFormatter(Stream stream);
    }
}
