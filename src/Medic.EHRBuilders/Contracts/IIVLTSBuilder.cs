using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IIVLTSBuilder : IDisposable
    {
        IIVLTSBuilder AddNullFlavor(CS cs);

        IIVLTSBuilder AddLow(TS ts);

        IIVLTSBuilder AddHigh(TS ts);

        IIVLTSBuilder LowClosed(bool closed);

        IIVLTSBuilder HighClosed(bool closed);

        IIVLTSBuilder AddWidth(Duration duration);

        IVLTS Build();

        IIVLTSBuilder Clear();
    }
}
