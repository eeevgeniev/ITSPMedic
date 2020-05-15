using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Transfer
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Transfer>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.FirstMainDiag)
                    .WithOne(d => d.FirstPatientTransfer)
                    .HasForeignKey<Transfer>(model => model.FirstMainDiagId);

                b.HasOne(model => model.SecondMainDiag)
                    .WithOne(d => d.SecondPatientTransfer)
                    .HasForeignKey<Transfer>(model => model.SecondMainDiagId);

                b.Property(model => model.DischargeWard).HasColumnType("decimal(15,4)");

                b.Property(model => model.TransferWard).HasColumnType("decimal(15,4)");
            });
        }
    }
}
