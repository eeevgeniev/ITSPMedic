using Medic.Formatters.Contracts;
using Medic.Formatters.Enums;
using Medic.Formatters.Implementors;
using System;
using System.IO;

namespace Medic.Formatters
{
    public sealed class FormatterFactory : IFormattableFactory
    {
        private bool _isDisposed = false;
        
        private JsonFormatter _jsonFormatter;
        private XMLFormatter _xMLFormatter;

        public IExcelFormattable CreateExcelFormatter(Stream stream)
        {
            if (stream == default)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            
            return new ExcelFormatter(stream);
        }

        public IDataFormattable CreateFormatter(FormatterEnum formatter)
        {
            switch (formatter)
            {
                case FormatterEnum.Json:
                    if (_jsonFormatter == default)
                    {
                        _jsonFormatter = new JsonFormatter();
                    }

                    return _jsonFormatter;
                case FormatterEnum.XML:
                    if (_xMLFormatter == default)
                    {
                        _xMLFormatter = new XMLFormatter();
                    }

                    return _xMLFormatter;
                default:
                    throw new InvalidOperationException();
            }
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _jsonFormatter = null;
                _xMLFormatter = null;

                GC.SuppressFinalize(this);

                _isDisposed = !_isDisposed;
            }
        }
    }
}