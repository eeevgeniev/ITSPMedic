using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class SpecialtyType
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<SpecialtyType>(b =>
            {
                b.HasKey(model => model.Id);
                b.Property(model => model.Name).HasMaxLength(200);
                b.Property(model => model.SpecialtyCode).HasMaxLength(200);
                b.HasIndex(model => model.Name).IsUnique();
                b.HasIndex(model => model.SpecialtyCode).IsUnique();
            });
        }
    }
}