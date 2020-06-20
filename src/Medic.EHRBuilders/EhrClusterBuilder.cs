using Medic.EHR.Clinical;
using Medic.EHR.Clinical.Base;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.EHRBuilders
{
    public class EhrClusterBuilder : BaseEhrCopy, IEhrClusterBuilder
    {
        private bool _isDisposed = false;
        
        private Cluster Cluster;

        public EhrClusterBuilder()
        {
            Cluster = new Cluster();
        }

        public IEhrClusterBuilder AddPart(Item item)
        {
            if (item == default)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (Cluster.Parts == default)
            {
                Cluster.Parts = new List<Item>();
            }

            Cluster.Parts.Add(item);

            return this;
        }

        public Cluster Build()
        {
            return base.CreateDeepCopy<Cluster>(Cluster);
        }

        public IEhrClusterBuilder Clear()
        {
            Cluster = new Cluster();

            return this;
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                Cluster = null;

                _isDisposed = !_isDisposed;
                GC.SuppressFinalize(this);
            }
        }
    }
}