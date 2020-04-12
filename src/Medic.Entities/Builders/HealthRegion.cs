using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class HealthRegion
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<HealthRegion>(b =>
            {
                b.HasKey(model => model.Id);
                b.Property(model => model.Name).HasMaxLength(200);
                b.Property(model => model.Code).IsRequired().HasMaxLength(200);
                b.HasIndex(model => model.Code).IsUnique(true);
            });
        }
    }
}