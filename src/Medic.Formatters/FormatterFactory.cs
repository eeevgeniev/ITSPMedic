using Medic.Formatters.Contracts;
using Medic.Formatters.Enums;
using Medic.Formatters.Implementors;
using Medic.Resources.Contracts;
using System;
using System.IO;
using System.Threading;

namespace Medic.Formatters
{
    public sealed class FormatterFactory : IFormattableFactory
    {
        private bool _isDisposed = false;

        private ReaderWriterLockSlim _locker = new ReaderWriterLockSlim();

        private JsonFormatter _jsonFormatter;
        private XMLFormatter _xMLFormatter;

        public IExcelFormattable CreateExcelFormatter(Stream stream, ILocalizationService localization)
        {
            if (stream == default)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (localization == default)
            {
                throw new ArgumentNullException(nameof(localization));
            }

            return new ExcelFormatter(stream, localization);
        }

        public IDataFormattable CreateFormatter(FormatterEnum formatter)
        {
            switch (formatter)
            {
                case FormatterEnum.Json:
                    if (_jsonFormatter == default)
                    {
                        _locker.EnterWriteLock();

                        if (_jsonFormatter == default)
                        {
                            _jsonFormatter = new JsonFormatter();
                        }

                        _locker.ExitWriteLock();
                    }

                    return _jsonFormatter;
                case FormatterEnum.XML:
                    if (_xMLFormatter == default)
                    {
                        _locker.EnterWriteLock();

                        if (_xMLFormatter == default)
                        {
                            _xMLFormatter = new XMLFormatter();
                        }

                        _locker.ExitWriteLock();
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

                _locker?.Dispose();

                GC.SuppressFinalize(this);

                _isDisposed = !_isDisposed;
            }
        }
    }
}