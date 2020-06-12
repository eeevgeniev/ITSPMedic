using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Histology
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Histology>(b =>
            {
                b.HasKey(model => model.Id);

                b.Property(model => model.NameHS).HasMaxLength(4000);

                b.Property(model => model.CodeHS).HasMaxLength(10);
            });
        }
    }
}
