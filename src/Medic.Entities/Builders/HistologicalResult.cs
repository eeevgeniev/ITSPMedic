using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class HistologicalResult
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<HistologicalResult>(b =>
            {
                b.HasKey(model => model.Id);
            });
        }
    }
}
