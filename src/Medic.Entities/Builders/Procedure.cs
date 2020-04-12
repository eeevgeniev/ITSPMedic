using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Procedure
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Procedure>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Implant)
                    .WithOne(i => i.Procedure)
                    .HasForeignKey<Procedure>(model => model.ImplantId);
            });
        }
    }
}