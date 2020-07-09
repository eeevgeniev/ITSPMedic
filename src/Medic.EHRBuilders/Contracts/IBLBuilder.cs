using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IBLBuilder : IDisposable
    {
        IBLBuilder AddValue(bool value);

        IBLBuilder AddNullFlavor(CS cs);

        BL Build();

        IBLBuilder Clear();
    }
}
