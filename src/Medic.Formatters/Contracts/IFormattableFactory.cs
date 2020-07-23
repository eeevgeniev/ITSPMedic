namespace Medic.Formatters.Contracts
{
    public interface IFormattableFactory
    {
        IDataFormattable CreateXMLFormatter();

        IDataFormattable CreateJsonFormatter();
    }
}
