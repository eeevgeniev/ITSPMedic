using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CLPR -> APr38
    /// </summary>
    [Serializable]
    public partial class APr38 : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }
        
        public int Height { get; set; }

        public int Weight { get; set; }

        public string History { get; set; }

        public string FairCondition { get; set; }

        public string Therapy { get; set; }

        public int? DecisionId { get; set;  }

        public Evaluation Decision { get; set; }

        public CommissionApr CommissionApr { get; set; }
    }
}