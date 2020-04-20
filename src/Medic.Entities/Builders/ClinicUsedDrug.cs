using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class ClinicUsedDrug
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<ClinicUsedDrug>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.VersionCode)
                    .WithOne(vc => vc.ClinicUsedDrug)
                    .HasForeignKey<ClinicUsedDrug>(model => model.VersionCodeId);

                b.Property(model => model.DrugCode).HasMaxLength(10);

                b.Property(model => model.DrugName).HasMaxLength(200);

                b.Property(model => model.ICDDrug).HasMaxLength(10);

                b.Property(model => model.UINPrescr).HasMaxLength(20);

                b.Property(model => model.NoPrescr).HasMaxLength(10);

                b.Property(model => model.PracticeCodeProtocol).HasMaxLength(20);
            });
        }
    }
}
