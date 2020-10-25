using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Out
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Out>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Patient)
                    .WithMany(p => p.Outs)
                    .HasForeignKey(model => model.PatientId);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.HasOne(model => model.PatientBranch)
                    .WithMany(pb => pb.Outs)
                    .HasForeignKey(model => model.PatientBranchId);

                b.HasIndex(model => model.PatientBranchId).IsUnique(false);

                b.HasOne(model => model.PatientHRegion)
                    .WithMany(hr => hr.Outs)
                    .HasForeignKey(model => model.PatientHRegionId);

                b.HasIndex(model => model.PatientHRegionId).IsUnique(false);

                b.HasOne(model => model.Sender)
                    .WithMany(hp => hp.Outs)
                    .HasForeignKey(model => model.SenderId);

                b.HasIndex(model => model.SenderId).IsUnique(false);

                b.HasMany(model => model.SendDiagnoses)
                    .WithOne(d => d.SendOut)
                    .HasForeignKey(d => d.SendOutId);

                b.HasMany(model => model.Diagnoses)
                    .WithOne(d => d.Out)
                    .HasForeignKey(d => d.OutId);

                b.HasOne(model => model.Dead)
                    .WithOne(d => d.OutDead)
                    .HasForeignKey<Out>(model => model.DeadId);

                b.HasIndex(model => model.DeadId).IsUnique(false);

                b.HasOne(model => model.OutMainDiagnose)
                    .WithOne(d => d.OutMain)
                    .HasForeignKey<Out>(main => main.OutMainDiagnoseId);

                b.HasIndex(model => model.OutMainDiagnoseId).IsUnique(false);

                b.HasMany(model => model.OutDiagnoses)
                    .WithOne(d => d.OutOut)
                    .HasForeignKey(d => d.OutOutId);

                b.HasMany(model => model.Procedures)
                    .WithOne(p => p.Out)
                    .HasForeignKey(p => p.OutId);

                b.HasOne(model => model.HistologicalResult)
                    .WithOne(hr => hr.Out)
                    .HasForeignKey<Out>(model => model.HistologicalResultId);

                b.HasIndex(model => model.HistologicalResultId).IsUnique(false);

                b.HasOne(model => model.Epicrisis)
                    .WithOne(e => e.Out)
                    .HasForeignKey<Out>(model => model.EpicrisisId);

                b.HasIndex(model => model.EpicrisisId).IsUnique(false);

                b.HasMany(model => model.UsedDrugs)
                    .WithOne(ud => ud.Out)
                    .HasForeignKey(ud => ud.OutId);

                b.HasOne(model => model.Resign)
                    .WithOne(r => r.Out)
                    .HasForeignKey<Out>(model => model.ResignId);

                b.HasIndex(model => model.ResignId).IsUnique(false);

                b.HasOne(model => model.Redirected)
                    .WithOne(r => r.Out)
                    .HasForeignKey<Out>(model => model.RedirectedId);

                b.HasIndex(model => model.RedirectedId).IsUnique(false);

                b.HasIndex(model => model.CPFileId).IsUnique(false);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.Property(model => model.UniqueIdentifier).HasMaxLength(12);

                b.Property(model => model.OutUniqueIdentifier).HasMaxLength(12);

                b.Property(model => model.BirthPractice).HasMaxLength(12);

                b.Property(model => model.OutAPr).HasMaxLength(12);

                b.Property(model => model.HLNumber).HasMaxLength(12);

                b.Property(model => model.IZinDetail).HasMaxLength(4000);

                b.Property(model => model.LinkMedia).HasMaxLength(250);
            });
        }
    }
}