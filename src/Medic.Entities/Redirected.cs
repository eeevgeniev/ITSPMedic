using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> Redirected
    /// </summary>
    public partial class Redirected : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public Out Out { get; set; }

        public int? PracticeId { get; set; }

        public Practice Practice { get; set; }

        public int? DiagnoseId { get; set; }

        public Diagnose Diagnose { get; set; }
    }
}
