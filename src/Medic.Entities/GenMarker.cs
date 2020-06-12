using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> GenMarker
    /// </summary>
    [Serializable]
    public partial class GenMarker : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Sign { get; set; }

        public int? ChemotherapyPartId { get; set; }

        public ChemotherapyPart ChemotherapyPart { get; set; }

        public ICollection<Marker> Markers { get; set; } = new HashSet<Marker>();
    }
}