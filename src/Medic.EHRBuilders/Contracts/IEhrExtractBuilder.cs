using Medic.EHR.Clinical;
using Medic.EHR.Components;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IEhrExtractBuilder : IDisposable
    {
        IEhrExtractBuilder AddEhrSystem(string rootName, string extension, string identifierName);

        IEhrExtractBuilder AddEhrId(string rootName, string extension, string identifierName);

        IEhrExtractBuilder AddCreationTime();

        IEhrExtractBuilder AddCreationTime(DateTime dateTime);

        IEhrExtractBuilder AddPolicyId(string policy);

        IEhrExtractBuilder AddRmId(string rmId);

        IEhrExtractBuilder AddFolder(Folder folder);

        EhrExtractBuilder AddComposition(Composition composition);

        EHRExtract Build();

        IEhrExtractBuilder Clear();
    }
}
