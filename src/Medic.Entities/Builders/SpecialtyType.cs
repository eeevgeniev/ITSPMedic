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
                
                b.HasIndex(model => model.SpecialtyCode).IsUnique();

                b.HasIndex(model => model.Name).IsUnique();
                
                b.Property(model => model.Name).HasMaxLength(200);
            });
        }
    }
}