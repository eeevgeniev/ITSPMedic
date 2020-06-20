using Medic.EHR.Clinical;
using Medic.EHR.Primitives.Base;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IEhrElementBuilder : IDisposable
    {
        IEhrElementBuilder AddValue(EHRDataValue value);

        IEhrElementBuilder AddIdentifierName(string identifierName);

        Element Build();

        IEhrElementBuilder Clear();
    }
}