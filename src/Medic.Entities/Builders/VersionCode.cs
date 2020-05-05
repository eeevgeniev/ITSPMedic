using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class VersionCode
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<VersionCode>(b =>
            {
                b.HasKey(model => model.Id);

                b.Property(model => model.BatchNumber).HasMaxLength(12);

                b.Property(model => model.QuantityPack).HasColumnType("decimal(15,4)");
            });
        }
    }
}
