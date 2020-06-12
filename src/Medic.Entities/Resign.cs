using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> Resign
    /// </summary>
    public partial class Resign : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }
        
        public int OutRefuse { get; set; }

        public string Notes { get; set; }

        public Out Out { get; set; }
    }
}
