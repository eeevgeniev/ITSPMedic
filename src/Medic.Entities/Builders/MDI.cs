using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class MDI
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<MDI>(b =>
            {
                b.HasKey(model => model.Id);
            });
        }
    }
}