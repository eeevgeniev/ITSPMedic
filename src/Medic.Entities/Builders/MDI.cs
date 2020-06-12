using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class MDI
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<MDI>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasIndex(model => model.DispObservationId).IsUnique(false);

                b.Property(model => model.MDIName).HasMaxLength(200);

                b.Property(model => model.ACHIcode).HasMaxLength(12);

                b.Property(model => model.MDICode).HasColumnType("decimal(15,4)");
            });
        }
    }
}