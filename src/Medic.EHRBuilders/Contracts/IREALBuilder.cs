using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IREALBuilder : IDisposable
    {
        IREALBuilder AddValue(double value);

        IREALBuilder AddNullFlavor(CS cs);

        REAL Build();

        IREALBuilder Clear();
    }
}
