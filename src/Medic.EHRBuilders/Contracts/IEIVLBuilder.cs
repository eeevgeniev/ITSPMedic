using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IEIVLBuilder : IDisposable
    {
        IEIVLBuilder AddNullFlavor(CS cs);

        IEIVLBuilder AddEvent(CD eventValue);

        IEIVLBuilder AddOffset(Duration offset);

        EIVL Build();

        IEIVLBuilder Clear();
    }
}
