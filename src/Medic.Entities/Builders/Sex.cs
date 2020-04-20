using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Sex
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Sex>(b =>
            {
                b.HasKey(model => model.Id);
                b.HasIndex(model => model.Name).IsUnique();

                b.Property(model => model.Name).HasMaxLength(20);
            });
        }
    }
}