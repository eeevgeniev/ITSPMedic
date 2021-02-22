using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class CommissionApr
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<CommissionApr>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Patient)
                    .WithMany(p => p.CommissionAprs)
                    .HasForeignKey(model => model.PatientId);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.HasOne(model => model.PatientBranch)
                    .WithMany(pb => pb.CommissionAprs)
                    .HasForeignKey(model => model.PatientBranchId);

                b.HasIndex(model => model.PatientBranchId).IsUnique(false);

                b.HasOne(model => model.PatientHRegion)
                    .WithMany(hr => hr.CommissionAprs)
                    .HasForeignKey(model => model.PatientHRegionId);

                b.HasIndex(model => model.PatientHRegionId).IsUnique(false);

                b.HasOne(model => model.Sender)
                    .WithMany(hp => hp.CommissionAprs)
                    .HasForeignKey(model => model.SenderId);

                b.HasIndex(model => model.SenderId).IsUnique(false);

                b.HasOne(model => model.Chairman)
                    .WithMany(hp => hp.ChairmanOfCommissionAprs)
                    .HasForeignKey(model => model.ChairmanId);

                b.HasIndex(model => model.ChairmanId).IsUnique(false);

                b.HasOne(model => model.MainDiag)
                    .WithOne(d => d.CommissionAprMain)
                    .HasForeignKey<CommissionApr>(model => model.MainDiagId);

                b.HasIndex(model => model.MainDiagId).IsUnique(false);

                b.HasMany(model => model.AddDiags)
                    .WithOne(d => d.CommissionApr)
                    .HasForeignKey(d => d.CommissionAprId);

                b.HasOne(model => model.APr05)
                    .WithOne(a => a.CommissionApr)
                    .HasForeignKey<CommissionApr>(model => model.APr05Id);

                b.HasIndex(model => model.APr05Id).IsUnique(false);

                b.HasOne(model => model.APr38)
                    .WithOne(a => a.CommissionApr)
                    .HasForeignKey<CommissionApr>(model => model.APr38Id);

                b.HasIndex(model => model.APr38Id).IsUnique(false);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.HasIndex(model => model.HospitalPracticeId).IsUnique(false);

                b.HasMany(model => model.Members)
                    .WithOne(cahp => cahp.CommissionApr)
                    .HasForeignKey(cahp => cahp.CommissionAprId);

                b.Property(model => model.AprSend).HasMaxLength(10);

                b.Property(model => model.AprPriem).HasMaxLength(10);
            });
        }
    }
}
