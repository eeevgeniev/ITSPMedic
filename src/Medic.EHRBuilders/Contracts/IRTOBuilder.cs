using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IRTOBuilder : IDisposable
    {
        IRTOBuilder AddNullFlavor(CS cs);

        IRTOBuilder AddNumerator(PQ numerator);

        IRTOBuilder AddDenominator(PQ denominator);

        RTO Build();

        IRTOBuilder Clear();
    }
}
