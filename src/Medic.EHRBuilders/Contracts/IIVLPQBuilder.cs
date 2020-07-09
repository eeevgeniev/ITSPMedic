using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IIVLPQBuilder : IDisposable
    {
        IIVLPQBuilder AddNullFlavor(CS cs);

        IIVLPQBuilder AddLow(PQ low);

        IIVLPQBuilder AddHigh(PQ high);

        IIVLPQBuilder LowClosed(bool closed);

        IIVLPQBuilder HighClosed(bool closed);

        IIVLPQBuilder AddWidth(PQ width);

        IVLPQ Build();

        IIVLPQBuilder Clear();
    }
}
