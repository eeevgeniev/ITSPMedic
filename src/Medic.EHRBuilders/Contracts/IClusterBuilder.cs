using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.RM;
using Medic.EHR.RM.Base;
using System;

namespace Medic.EHRBuilders.Contracts 
{
    public interface IClusterBuilder : IDisposable
    {
        public IClusterBuilder AddName(Text name);

        public IClusterBuilder AddArchetypeId(string archetypeId);

        public IClusterBuilder AddRcId(II rcId);

        public IClusterBuilder AddMeaning(CV meaning);

        public IClusterBuilder AddSynthesised(bool synthesised);

        public IClusterBuilder AddPolicyIds(params II[] policyIds);

        public IClusterBuilder AddSensitivity(int sensitivity);

        public IClusterBuilder AddOrigParentRef(II origParentRef);

        public IClusterBuilder AddLinks(params Link[] links);

        public IClusterBuilder AddEmphasis(CV emphasis);

        public IClusterBuilder AddObsTime(IVLTS obsTime);

        public IClusterBuilder AddItemCategory(CS itemCategory);

        public IClusterBuilder AddStructureType(CS structureType);

        public IClusterBuilder AddParts(params Item[] parts);


        Cluster Build();

        IClusterBuilder Clear();
    }
}
