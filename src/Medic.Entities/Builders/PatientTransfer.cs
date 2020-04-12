using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class PatientTransfer
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<PatientTransfer>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.FirstMainDiag)
                    .WithOne(d => d.FirstPatientTransfer)
                    .HasForeignKey<PatientTransfer>(model => model.FirstMainDiagId);

                b.HasOne(model => model.SecondMainDiag)
                    .WithOne(d => d.SecondPatientTransfer)
                    .HasForeignKey<PatientTransfer>(model => model.SecondMainDiagId);
            });
        }
    }
}
