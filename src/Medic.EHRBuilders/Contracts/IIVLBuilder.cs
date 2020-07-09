using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IIVLBuilder : IDisposable
    {
        IIVLBuilder AddNullFlavor(CS cs);

        IIVLBuilder AddLow(Quantity quantity);

        IIVLBuilder AddHigh(Quantity quantity);

        IIVLBuilder LowClosed(bool closed);

        IIVLBuilder HighClosed(bool closed);

        IIVLBuilder AddWidth(Quantity quantity);

        IVL Build();

        IIVLBuilder Clear();
    }
}
