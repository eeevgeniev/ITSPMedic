using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;

namespace Medic.Entities
{
    public partial class VSD : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }
        
        public string NameVSD { get; set; }

        public string CodeVSD { get; set; }

        public string ACHIcode { get; set; }

        public int DispObservationId { get; set; }

        public DispObservation DispObservation { get; set; }
    }
}
