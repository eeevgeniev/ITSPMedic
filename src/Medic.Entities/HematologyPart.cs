using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> HematologyPart
    /// </summary>
    [Serializable]
    public partial class HematologyPart : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int? PredMarkerId { get; set; }

        public Evaluation PredMarker { get; set; }

        public ProtocolDrugTherapy ProtocolDrugTherapy { get; set; }
    }
}
