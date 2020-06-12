using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Marker
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Marker>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.GenMarker)
                    .WithMany(gm => gm.Markers)
                    .HasForeignKey(model => model.GenMarkerId);

                b.HasIndex(model => model.GenMarkerId).IsUnique(false);

                b.HasOne(model => model.Evaluation)
                    .WithMany(e => e.Markers)
                    .HasForeignKey(model => model.EvaluationId);

                b.HasIndex(model => model.EvaluationId).IsUnique(false);
            });
        }
    }
}
