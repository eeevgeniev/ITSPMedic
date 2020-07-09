using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IORDBulder : IDisposable
    {
        IORDBulder AddNullFlavor(CS cs);

        IORDBulder AddValue(int value);

        IORDBulder AddSymbol(CodedText symbol);

        ORD Build();

        IORDBulder Clear();
    }
}
