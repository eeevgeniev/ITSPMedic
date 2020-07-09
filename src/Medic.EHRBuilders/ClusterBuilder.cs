using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.RM;
using Medic.EHR.RM.Base;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.EHRBuilders
{
    public class ClusterBuilder : DataValueBuilder, IClusterBuilder
    {
        private Cluster _value;

        public ClusterBuilder()
        {
            Clear();
        }
        
        public IClusterBuilder AddArchetypeId(string archetypeId)
        {
            _value.ArchetypeId = archetypeId;

            return this;
        }

        public IClusterBuilder AddEmphasis(CV emphasis)
        {
            _value.Emphasis = emphasis;

            return this;
        }

        public IClusterBuilder AddItemCategory(CS itemCategory)
        {
            _value.ItemCategory = itemCategory;

            return this;
        }

        public IClusterBuilder AddLinks(params Link[] links)
        {
            if (links == default || links.Length == 0)
            {
                return this;
            }

            if (_value.Links == default)
            {
                _value.Links = new List<Link>();
            }

            _value.Links.AddRange(links);

            return this;
        }

        public IClusterBuilder AddMeaning(CV meaning)
        {
            _value.Meaning = meaning;

            return this;
        }

        public IClusterBuilder AddName(Text name)
        {
            _value.Name = name;

            return this;
        }

        public IClusterBuilder AddObsTime(IVLTS obsTime)
        {
            _value.ObsTime = obsTime;

            return this;
        }

        public IClusterBuilder AddOrigParentRef(II origParentRef)
        {
            _value.OrigParentRef = origParentRef;

            return this;
        }

        public IClusterBuilder AddParts(params Item[] parts)
        {
            if (parts == default || parts.Length == 0)
            {
                return this;
            }

            if (_value.Parts == default)
            {
                _value.Parts = new List<Item>();
            }

            _value.Parts.AddRange(parts);

            return this;
        }

        public IClusterBuilder AddPolicyIds(params II[] policyIds)
        {
            if (policyIds == default || policyIds.Length == 0)
            {
                return this;
            }

            if (_value.PolicyIds == default)
            {
                _value.PolicyIds = new List<II>();
            }

            _value.PolicyIds.AddRange(policyIds);

            return this;
        }

        public IClusterBuilder AddRcId(II rcId)
        {
            _value.RcId = rcId;

            return this;
        }

        public IClusterBuilder AddSensitivity(int sensitivity)
        {
            _value.Sensitivity = sensitivity;

            return this;
        }

        public IClusterBuilder AddStructureType(CS structureType)
        {
            _value.StructureType = structureType;

            return this;
        }

        public IClusterBuilder AddSynthesised(bool synthesised)
        {
            _value.Synthesised = synthesised;

            return this;
        }

        public Cluster Build() => base.DeepClone<Cluster>(_value);

        public IClusterBuilder Clear()
        {
            _value = base.ResetValue<Cluster>();

            return this;
        }

        public override void Dispose()
        {
            if (!base._isDisposed)
            {
                _value = null;
                GC.SuppressFinalize(this);
                base._isDisposed = !base._isDisposed;
            }
        }
    }
}
