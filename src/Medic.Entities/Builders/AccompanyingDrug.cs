using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class AccompanyingDrug 
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<AccompanyingDrug>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.TherapyType)
                    .WithMany(tt => tt.AccompanyingDrugs)
                    .HasForeignKey(model => model.TherapyTypeId);

                b.HasIndex(model => model.TherapyTypeId).IsUnique(false);

                b.HasIndex(model => model.ProtocolDrugTherapyId).IsUnique(false);

                b.Property(model => model.ATCCode).HasMaxLength(20);

                b.Property(model => model.ATCName).HasMaxLength(200);

                b.Property(model => model.SingleDose).HasColumnType("decimal(12,4)");

                b.Property(model => model.AllDose).HasColumnType("decimal(12,4)");
            });
        }
    }
}