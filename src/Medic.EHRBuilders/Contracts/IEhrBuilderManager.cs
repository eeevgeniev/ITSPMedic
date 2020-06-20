using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IEhrBuilderManager : IDisposable
    {
        IEhrClusterBuilder GetClusterBuilder { get; }

        IEhrCompositionBuilder GetIEhrCompositionBuilder { get; }

        IEhrElementBuilder GetIEhrElementBuilder { get; }

        IEhrEntryBuilder GetIEhrEntryBuilder { get; }

        IEhrExtractBuilder GetIEhrExtractBuilder { get; }

        IEhrFolderBuilder GetIEhrFolderBuilder { get; }

        IEhrSectionBuilder GetIEhrSectionBuilder { get; }

        IEhrValueFactory GetValueFactory { get; }
    }
}
