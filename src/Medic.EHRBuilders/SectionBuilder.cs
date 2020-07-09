using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.RM;
using Medic.EHR.RM.Base;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.EHRBuilders
{
    public class SectionBuilder : DataValueBuilder, ISectionBuilder
    {
        private Section _value;

        public SectionBuilder()
        {
            Clear();
        }
        
        public ISectionBuilder AddArchetypeId(string archetypeId)
        {
            _value.ArchetypeId = archetypeId;

            return this;
        }

        public ISectionBuilder AddFeederAudit(AuditInfo feederAudit)
        {
            _value.FeederAudit = feederAudit;

            return this;
        }

        public ISectionBuilder AddLinks(params Link[] links)
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

        public ISectionBuilder AddMeaning(CV meaning)
        {
            _value.Meaning = meaning;

            return this;
        }

        public ISectionBuilder AddMembers(params Content[] members)
        {
            if (members == default || members.Length == 0)
            {
                return this;
            }

            if (_value.Members == default)
            {
                _value.Members = new List<Content>();
            }

            _value.Members.AddRange(members);

            return this;
        }

        public ISectionBuilder AddName(Text name)
        {
            _value.Name = name;

            return this;
        }

        public ISectionBuilder AddOrigParentRef(II origParentRef)
        {
            _value.OrigParentRef = origParentRef;

            return this;
        }

        public ISectionBuilder AddPolicyIds(params II[] policyIds)
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

        public ISectionBuilder AddRcId(II rcId)
        {
            _value.RcId = rcId;

            return this;
        }

        public ISectionBuilder AddSensitivity(int sensitivity)
        {
            _value.Sensitivity = sensitivity;

            return this;
        }

        public ISectionBuilder AddSynthesised(bool synthesised)
        {
            _value.Synthesised = synthesised;

            return this;
        }

        public Section Build() => base.DeepClone<Section>(_value);

        public ISectionBuilder Clear()
        {
            _value = base.ResetValue<Section>();

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
