using Medic.FileImport.Contracts;
using System;

namespace Medic.FileImport.Writer
{
    internal class ConsoleWriter : INotifiable
    {
        void INotifiable.Notify(string message)
        {
            Console.WriteLine(message);
        }
    }
}
