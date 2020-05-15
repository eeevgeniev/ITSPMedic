using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    [Serializable]
    public partial class TherapyType : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }

        public ICollection<AccompanyingDrug> AccompanyingDrugs { get; set; } = new HashSet<AccompanyingDrug>();

        public ICollection<DrugProtocol> DrugProtocols { get; set; } = new HashSet<DrugProtocol>();
    }
}
