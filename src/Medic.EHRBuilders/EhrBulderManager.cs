using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class EhrBulderManager : IEhrBuilderManager
    {
        private bool _isDisposed = false;

        private EhrClusterBuilder EhrClusterBuilder;
        private EhrCompositionBuilder EhrCompositionBuilder;
        private EhrElementBuilder EhrElementBuilder;
        private EhrEntryBuilder EhrEntryBuilder;
        private EhrExtractBuilder EhrExtractBuilder;
        private EhrFolderBuilder EhrFolderBuilder;
        private EhrSectionBuilder EhrSectionBuilder;
        private EhrValueFactory EhrValueFactory;

        public EhrBulderManager()
        {
            EhrClusterBuilder = new EhrClusterBuilder();
            EhrCompositionBuilder = new EhrCompositionBuilder();
            EhrElementBuilder = new EhrElementBuilder();
            EhrEntryBuilder = new EhrEntryBuilder();
            EhrExtractBuilder = new EhrExtractBuilder();
            EhrFolderBuilder = new EhrFolderBuilder();
            EhrSectionBuilder = new EhrSectionBuilder();
            EhrValueFactory = new EhrValueFactory();
        }

        public IEhrClusterBuilder GetClusterBuilder => EhrClusterBuilder;

        public IEhrCompositionBuilder GetIEhrCompositionBuilder => EhrCompositionBuilder;

        public IEhrElementBuilder GetIEhrElementBuilder => EhrElementBuilder;

        public IEhrEntryBuilder GetIEhrEntryBuilder => EhrEntryBuilder;

        public IEhrExtractBuilder GetIEhrExtractBuilder => EhrExtractBuilder;

        public IEhrFolderBuilder GetIEhrFolderBuilder => EhrFolderBuilder;

        public IEhrSectionBuilder GetIEhrSectionBuilder => EhrSectionBuilder;

        public IEhrValueFactory GetValueFactory => EhrValueFactory;

        public void Dispose()
        {
            if (!_isDisposed)
            {
                EhrClusterBuilder.Dispose();
                EhrClusterBuilder = null;

                EhrCompositionBuilder.Dispose();
                EhrCompositionBuilder = null;

                EhrElementBuilder.Dispose();
                EhrElementBuilder = null;

                EhrEntryBuilder.Dispose();
                EhrEntryBuilder = null;

                EhrExtractBuilder.Dispose();
                EhrExtractBuilder = null;

                EhrFolderBuilder.Dispose();
                EhrFolderBuilder = null;

                EhrSectionBuilder.Dispose();
                EhrSectionBuilder = null;

                _isDisposed = !_isDisposed;

                GC.SuppressFinalize(this);
            }
        }
    }
}