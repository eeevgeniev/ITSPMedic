using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CLPR -> MDI
    /// </summary>
    [Serializable]
    public partial class MDI : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public string MDIName { get; set; }

        public decimal? MDICode { get; set; }

        public string ACHIcode { get; set; }

        public int DispObservationId { get; set; }

        public DispObservation DispObservation { get; set; }
    }
}