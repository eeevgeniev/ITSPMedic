using Medic.EHR.Clinical;
using Medic.EHR.Clinical.Base;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IEhrCompositionBuilder : IDisposable
    {
        IEhrCompositionBuilder AddComposer(string rootName, string extension, string identifierName);

        IEhrCompositionBuilder AddPolicyIds(string rootName, string extension, string identifierName);

        IEhrCompositionBuilder AddContent(Content content);

        IEhrCompositionBuilder AddSensitivity(string sensitivity);

        Composition Build();

        IEhrCompositionBuilder Clear();
    }
}
