using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IPIVLBuilder : IDisposable
    {
        IPIVLBuilder AddNullFlavor(CS cs);

        IPIVLBuilder AddPhase(IVLTS phase);

        IPIVLBuilder AddPeriod(Duration period);

        IPIVLBuilder AddAlignment(CD alignment);

        PIVL Build();

        IPIVLBuilder Clear();
    }
}
