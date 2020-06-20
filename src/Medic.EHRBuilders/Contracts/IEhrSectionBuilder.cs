using Medic.EHR.Clinical;
using Medic.EHR.Clinical.Base;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IEhrSectionBuilder : IDisposable
    {
        IEhrSectionBuilder AddContent(Content content);

        Section Build();

        IEhrSectionBuilder Clear();
    }
}
