using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class In
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<In>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Patient)
                    .WithMany(p => p.Ins)
                    .HasForeignKey(model => model.PatientId);

                b.HasOne(model => model.PatientBranch)
                    .WithMany(pb => pb.Ins)
                    .HasForeignKey(model => model.PatientBranchId);

                b.HasOne(model => model.PatientHRegion)
                    .WithMany(hr => hr.Ins)
                    .HasForeignKey(model => model.PatientHRegionId);

                b.HasOne(model => model.Sender)
                    .WithMany(hp => hp.Ins)
                    .HasForeignKey(model => model.SenderId);

                b.HasOne(model => model.SendDiagnose)
                    .WithOne(d => d.In)
                    .HasForeignKey<In>(model => model.SendDiagnoseId);

                b.HasMany(model => model.Diagnoses)
                    .WithOne(d => d.MainIn)
                    .HasForeignKey(d => d.MainInId);
            });
        }
    }
}
