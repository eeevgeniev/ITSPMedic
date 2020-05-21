using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class TherapyType
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<TherapyType>(b =>
            {
                b.HasKey(model => model.Id);
                
                b.Property(model => model.Name).HasMaxLength(100);
                
                b.HasIndex(model => model.Code).IsUnique();
            });
        }
    }
}