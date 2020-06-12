using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> CP.Marker
    /// </summary>
    public partial class Marker : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int? Number { get; set; }

        public int Sign { get; set; }

        public int? GenMarkerId { get; set; } 

        public GenMarker GenMarker { get; set; }

        public int? EvaluationId { get; set; }

        public Evaluation Evaluation { get; set; }
    }
}
