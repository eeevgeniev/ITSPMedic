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
                b.HasIndex(model => model.Name).IsUnique();
                b.HasIndex(model => model.SpecialtyCode).IsUnique();

                b.Property(model => model.Name).HasMaxLength(200);
                b.Property(model => model.SpecialtyCode).HasMaxLength(5);
            });
        }
    }
}