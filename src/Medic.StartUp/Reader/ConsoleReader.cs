using Medic.FileImport.Contracts;
using System;

namespace Medic.FileImport.Reader
{
    internal class ConsoleReader : IReadable
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
