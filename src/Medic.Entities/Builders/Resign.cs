using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Resign
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Resign>(b =>
            {
                b.HasKey(model => model.Id);

                b.Property(model => model.Notes).HasMaxLength(4000);
            });
        }
    }
}
