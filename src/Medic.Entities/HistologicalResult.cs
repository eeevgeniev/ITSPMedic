using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> HistologicalResult
    /// </summary>
    [Serializable]
    public partial class HistologicalResult : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public decimal Code { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }

        public Out Out { get; set; }
    }
}