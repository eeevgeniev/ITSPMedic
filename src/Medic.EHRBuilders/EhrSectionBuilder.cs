using Medic.EHR.Clinical;
using Medic.EHR.Clinical.Base;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.EHRBuilders
{
    public class EhrSectionBuilder : BaseEhrCopy, IEhrSectionBuilder
    {
        private bool _isDisposed = false;

        private Section Section;

        public EhrSectionBuilder()
        {
            Section = new Section();
        }
        
        public IEhrSectionBuilder AddContent(Content content)
        {
            if (content == default)
            {
                throw new ArgumentNullException(nameof(content));
            }

            if (Section.Members == default)
            {
                Section.Members = new List<Content>();
            }

            Section.Members.Add(content);

            return this;
        }

        public Section Build()
        {
            return base.CreateDeepCopy<Section>(Section);
        }

        public IEhrSectionBuilder Clear()
        {
            Section = new Section();

            return this;
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                Section = null;

                _isDisposed = !_isDisposed;
                GC.SuppressFinalize(this);
            }
        }
    }
}
