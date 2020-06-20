using Medic.EHR.Clinical;
using Medic.EHR.Clinical.Base;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IEhrClusterBuilder : IDisposable
    {
        IEhrClusterBuilder AddPart(Item item);

        Cluster Build();

        IEhrClusterBuilder Clear();
    }
}
