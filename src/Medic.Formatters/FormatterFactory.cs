using Medic.Formatters.Contracts;

namespace Medic.Formatters
{
    public sealed class FormatterFactory : IFormattableFactory
    {
        public IDataFormattable CreateJsonFormatter()
        {
            return new JsonFormatter();
        }

        public IDataFormattable CreateXMLFormatter()
        {
            return new XMLFormatter();
        }
    }
}