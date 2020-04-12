using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Diagnose
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Diagnose>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Primary)
                    .WithMany(mkb => mkb.PrimaryDiagnoses)
                    .HasForeignKey(model => model.PrimaryCode);

                b.HasOne(model => model.Secondary)
                    .WithMany(mkb => mkb.SecondaryDiagnoses)
                    .HasForeignKey(model => model.SecondaryCode);
            });
        }
    }
}