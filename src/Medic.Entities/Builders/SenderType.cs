using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class SenderType
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<SenderType>(b =>
            {
                b.HasKey(model => model.Id);
                
                b.Property(model => model.Name).HasMaxLength(200);
                
                b.HasIndex(model => model.Name).IsUnique(false);

                b.HasIndex(model => model.Code).IsUnique(true);
            });
        }
    }
}