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
            });
        }
    }
}
