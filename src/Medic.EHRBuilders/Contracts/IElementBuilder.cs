using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.RM;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IElementBuilder : IDisposable
    {
        public IElementBuilder AddName(Text name);

        public IElementBuilder AddArchetypeId(string archetypeId);

        public IElementBuilder AddRcId(II rcId);

        public IElementBuilder AddMeaning(CV meaning);

        public IElementBuilder AddSynthesised(bool synthesised);

        public IElementBuilder AddPolicyIds(params II[] policyIds);

        public IElementBuilder AddSensitivity(int sensitivity);

        public IElementBuilder AddOrigParentRef(II origParentRef);

        public IElementBuilder AddLinks(params Link[] links);

        public IElementBuilder AddEmphasis(CV emphasis);

        public IElementBuilder AddObsTime(IVLTS obsTime);

        public IElementBuilder AddItemCategory(CS itemCategory);

        public IElementBuilder AddValue(DataValue value);

        Element Build();

        IElementBuilder Clear();
    }
}
