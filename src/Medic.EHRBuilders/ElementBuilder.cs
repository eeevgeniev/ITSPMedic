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
    public class ElementBuilder : DataValueBuilder, IElementBuilder
    {
        private Element _value;

        public ElementBuilder()
        {
            Clear();
        }
        
        public IElementBuilder AddArchetypeId(string archetypeId)
        {
            _value.ArchetypeId = archetypeId;

            return this;
        }

        public IElementBuilder AddEmphasis(CV emphasis)
        {
            _value.Emphasis = emphasis;

            return this;
        }

        public IElementBuilder AddItemCategory(CS itemCategory)
        {
            _value.ItemCategory = itemCategory;

            return this;
        }

        public IElementBuilder AddLinks(params Link[] links)
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

        public IElementBuilder AddMeaning(CV meaning)
        {
            _value.Meaning = meaning;

            return this;
        }

        public IElementBuilder AddName(Text name)
        {
            _value.Name = name;

            return this;
        }

        public IElementBuilder AddObsTime(IVLTS obsTime)
        {
            _value.ObsTime = obsTime;

            return this;
        }

        public IElementBuilder AddOrigParentRef(II origParentRef)
        {
            _value.OrigParentRef = origParentRef;

            return this;
        }

        public IElementBuilder AddPolicyIds(params II[] policyIds)
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

        public IElementBuilder AddRcId(II rcId)
        {
            _value.RcId = rcId;

            return this;
        }

        public IElementBuilder AddSensitivity(int sensitivity)
        {
            _value.Sensitivity = sensitivity;

            return this;
        }

        public IElementBuilder AddSynthesised(bool synthesised)
        {
            _value.Synthesised = synthesised;

            return this;
        }

        public IElementBuilder AddValue(DataValue value)
        {
            _value.Value = value;

            return this;
        }

        public Element Build() => base.DeepClone<Element>(_value);

        public IElementBuilder Clear()
        {
            _value = base.ResetValue<Element>();

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
