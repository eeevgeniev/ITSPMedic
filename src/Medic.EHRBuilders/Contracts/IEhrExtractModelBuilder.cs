using Medic.EHR.DataTypes;
using Medic.EHR.Extracts;
using Medic.EHR.RM;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IEhrExtractModelBuilder : IDisposable
    {
        IEhrExtractModelBuilder AddFolder(Folder folder);

        IEhrExtractModelBuilder AddComposition(Composition composition);

        IEhrExtractModelBuilder AddEhrSystem(II ehrSystem);

        IEhrExtractModelBuilder AddSubjectOfCare(II subjectOfCare);

        IEhrExtractModelBuilder AddTimeCreated(TS timeCreated);

        EhrExtract Build();

        IEhrExtractModelBuilder Clear();
    }
}
