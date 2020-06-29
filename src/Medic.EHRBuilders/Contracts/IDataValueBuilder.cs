using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IDataValueBuilder : IDisposable
    {
        IDataValueBuilder AddNullFlavor(CS cs);

        DataValue Build();
    }
}
