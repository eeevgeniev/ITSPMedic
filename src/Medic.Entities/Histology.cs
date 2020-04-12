using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> Histology
    /// </summary>
    [Serializable]
    public partial class Histology : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public string NameHS { get; set; }

        public string CodeHS { get; set; }

        public APr05 APr05 { get; set; }

        public ICollection<ChemotherapyPart> ChemotherapyParts { get; set; } = new HashSet<ChemotherapyPart>();
    }
}
