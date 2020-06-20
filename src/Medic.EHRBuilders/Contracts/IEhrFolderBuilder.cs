using Medic.EHR.Clinical;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IEhrFolderBuilder : IDisposable
    {
        IEhrFolderBuilder AddSubjectOfCare(string rootName, string extension, string identifierName);

        IEhrFolderBuilder AddSubFolder(Folder folder);

        IEhrFolderBuilder AddComposition(Composition composition);

        Folder Build();

        IEhrFolderBuilder Clear();
    }
}
