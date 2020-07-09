using Medic.EHR.RM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.EHRBuilders.Contracts
{
    public interface IReferenceModelBuilder : IDisposable
    {
        IReferenceModelBuilder AddFolder(Folder folder);

        IReferenceModelBuilder AddComposition(Composition composition);

        ReferenceModel Build();

        IReferenceModelBuilder Clear();
    }
}
