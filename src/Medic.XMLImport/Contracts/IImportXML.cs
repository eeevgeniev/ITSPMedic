using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.XMLImport.Contracts
{
    public interface IImportXML
    {
        void ImportCpFile();

        void ImportCLPRFiles();
    }
}
