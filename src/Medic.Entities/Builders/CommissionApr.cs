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

                b.HasOne(model => model.PatientBranch)
                    .WithMany(pb => pb.CommissionAprs)
                    .HasForeignKey(model => model.PatientBranchId);

                b.HasOne(model => model.PatientHRegion)
                    .WithMany(hr => hr.CommissionAprs)
                    .HasForeignKey(model => model.PatientHRegionId);

                b.HasOne(model => model.Sender)
                    .WithMany(hp => hp.CommissionAprs)
                    .HasForeignKey(model => model.SenderId);

                b.HasOne(model => model.Chairman)
                    .WithMany(hp => hp.ChairmanOfCommissionAprs)
                    .HasForeignKey(model => model.ChairmanId);

                b.HasOne(model => model.MainDiag)
                    .WithOne(d => d.CommissionAprMain)
                    .HasForeignKey<CommissionApr>(model => model.MainDiagId);

                b.HasMany(model => model.AddDiag)
                    .WithOne(d => d.CommissionApr)
                    .HasForeignKey(d => d.CommissionAprId);

                b.HasOne(model => model.APr05)
                    .WithOne(a => a.CommissionApr)
                    .HasForeignKey<CommissionApr>(model => model.APr05Id);

                b.HasOne(model => model.APr38)
                    .WithOne(a => a.CommissionApr)
                    .HasForeignKey<CommissionApr>(model => model.APr38Id);

                b.HasMany(model => model.Members)
                    .WithOne(cahp => cahp.CommissionApr)
                    .HasForeignKey(cahp => cahp.CommissionAprId);

                b.Property(model => model.AprSend).HasMaxLength(5);

                b.Property(model => model.AprPriem).HasMaxLength(5);
            });
        }
    }
}
