using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class MKB
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<MKB>(b =>
            {
                b.HasKey(model => model.Code);

                b.Property(model => model.Code).HasMaxLength(10);

                b.Property(model => model.Name).HasMaxLength(300);
            });
        }
    }
}