using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class HematologyPart
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<HematologyPart>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.PredMarker)
                    .WithOne(e => e.HematologyPart)
                    .HasForeignKey<HematologyPart>(model => model.PredMarkerId);
            });
        }
    }
}