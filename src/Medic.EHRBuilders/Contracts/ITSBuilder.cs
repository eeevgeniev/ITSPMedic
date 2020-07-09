using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface ITSBuilder : IDisposable
    {
        ITSBuilder AddTime(DateTime dateTime);

        ITSBuilder AddNullFlavor(CS cs);

        TS Build();

        ITSBuilder Clear();
    }
}
