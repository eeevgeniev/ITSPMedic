using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IPQBuilder : IDisposable
    {
        IPQBuilder AddNullFlavor(CS cs);

        IPQBuilder AddValue(double value);

        IPQBuilder AddUnits(CS units);

        IPQBuilder AddProperty(CD property);

        IPQBuilder AddPrecision(int precision);

        PQ Build();

        IPQBuilder Clear();
    }
}
