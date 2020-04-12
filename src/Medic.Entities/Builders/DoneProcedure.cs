using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class DoneProcedure
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<DoneProcedure>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Doctor)
                    .WithMany(hp => hp.DoneProcedures)
                    .HasForeignKey(model => model.DoctorId);
            });
        }
    }
}
