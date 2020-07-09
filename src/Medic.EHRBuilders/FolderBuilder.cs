using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.RM;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.EHRBuilders
{
    public class FolderBuilder : DataValueBuilder, IFolderBuilder
    {
        private Folder _value;

        public FolderBuilder()
        {
            Clear();
        }
        
        public IFolderBuilder AddArchetypeId(string archetypeId)
        {
            _value.ArchetypeId = archetypeId;

            return this;
        }

        public IFolderBuilder AddAttestations(params AttestationInfo[] attestations)
        {
            if (attestations == default || attestations.Length == 0)
            {
                return this;
            }

            if (_value.Attestations == default)
            {
                _value.Attestations = new List<AttestationInfo>();
            }

            _value.Attestations.AddRange(attestations);

            return this;
        }

        public IFolderBuilder AddCompositions(params II[] compositions)
        {
            if (compositions == default || compositions.Length == 0)
            {
                return this;
            }

            if (_value.Compositions == default)
            {
                _value.Compositions = new List<II>();
            }

            _value.Compositions.AddRange(compositions);

            return this;
        }

        public IFolderBuilder AddFeederAudit(AuditInfo feederAudit)
        {
            _value.FeederAudit = feederAudit;

            return this;
        }

        public IFolderBuilder AddLinks(params Link[] links)
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

        public IFolderBuilder AddMeaning(CV meaning)
        {
            _value.Meaning = meaning;

            return this;
        }

        public IFolderBuilder AddName(Text name)
        {
            _value.Name = name;

            return this;
        }

        public IFolderBuilder AddOrigParentRef(II origParentRef)
        {
            _value.OrigParentRef = origParentRef;

            return this;
        }

        public IFolderBuilder AddPolicyIds(params II[] policyIds)
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

        public IFolderBuilder AddRcId(II rcId)
        {
            _value.RcId = rcId;

            return this;
        }

        public IFolderBuilder AddSensitivity(int sensitivity)
        {
            _value.Sensitivity = sensitivity;

            return this;
        }

        public IFolderBuilder AddSubFolders(params Folder[] subFolders)
        {
            if (subFolders == default || subFolders.Length == 0)
            {
                return this;
            }

            if (_value.SubFolders == default)
            {
                _value.SubFolders = new List<Folder>();
            }

            _value.SubFolders.AddRange(subFolders);

            return this;
        }

        public IFolderBuilder AddSynthesised(bool synthesised)
        {
            _value.Synthesised = synthesised;

            return this;
        }

        public Folder Build() => base.DeepClone<Folder>(_value);

        public IFolderBuilder Clear()
        {
            _value = base.ResetValue<Folder>();

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
