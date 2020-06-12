using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Redirected
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Redirected>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Diagnose)
                    .WithOne(d => d.Redirected)
                    .HasForeignKey<Redirected>(model => model.DiagnoseId);

                b.HasIndex(model => model.DiagnoseId).IsUnique(false);

                b.HasOne(model => model.Practice)
                    .WithOne(p => p.Redirected)
                    .HasForeignKey<Redirected>(model => model.PracticeId);

                b.HasIndex(model => model.PracticeId).IsUnique(false);
            });
        }
    }
}
