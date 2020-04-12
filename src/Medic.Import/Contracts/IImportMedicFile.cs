using Medic.Entities;
using System;

namespace Medic.Import.Contracts
{
    public interface IImportMedicFile : IDisposable
    {
        CPFile ImportCPFile(CPFile cpFile);

        HospitalPractice ImportHospitalPractice(HospitalPractice hospitalPractice);
    }
}