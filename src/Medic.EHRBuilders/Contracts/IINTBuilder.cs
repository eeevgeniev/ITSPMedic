using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IINTBuilder : IDisposable
    {
        IINTBuilder AddValue(int value);

        IINTBuilder AddNullFlavor(CS cs);

        INT Build();

        IINTBuilder Clear();
    }
}
