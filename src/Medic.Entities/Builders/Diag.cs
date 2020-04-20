using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Diag
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Diag>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.MKB)
                    .WithMany(mkb => mkb.Diags)
                    .HasForeignKey(model => model.MKBCode);

                b.HasOne(model => model.LinkDMKB)
                    .WithMany(mkb => mkb.LinkedDiags)
                    .HasForeignKey(model => model.LinkDMKBCode);

                b.Property(model => model.ImeMD).HasMaxLength(500);

                b.Property(model => model.MKBCode).HasMaxLength(10);

                b.Property(model => model.LinkDName).HasMaxLength(200);

                b.Property(model => model.LinkDMKBCode).HasMaxLength(10);
            });
        }
    }
}