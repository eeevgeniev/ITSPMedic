using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class HospitalPractice
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<HospitalPractice>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.HealthRegion)
                    .WithMany(hr => hr.HospitalPractices)
                    .HasForeignKey(model => model.HealthRegionId);

                b.HasIndex(model => model.HealthRegionId).IsUnique(false);

                b.HasMany(model => model.InClinicProcedures)
                    .WithOne(icp => icp.HospitalPractice)
                    .HasForeignKey(icp => icp.HospitalPracticeId);

                b.HasMany(model => model.PathProcedures)
                    .WithOne(pp => pp.HospitalPractice)
                    .HasForeignKey(pp => pp.HospitalPracticeId);

                b.HasMany(model => model.DispObservations)
                    .WithOne(o => o.HospitalPractice)
                    .HasForeignKey(o => o.HospitalPracticeId);

                b.HasMany(model => model.CommissionAprs)
                    .WithOne(ca => ca.HospitalPractice)
                    .HasForeignKey(ca => ca.HospitalPracticeId);

                b.HasMany(model => model.ProtocolDrugTherapies)
                    .WithOne(pdt => pdt.HospitalPractice)
                    .HasForeignKey(pdt => pdt.HospitalPracticeId);

                b.HasMany(model => model.DrugResidues)
                    .WithOne(dr => dr.HospitalPractice)
                    .HasForeignKey(dr => dr.HospitalPracticeId);

                b.HasMany(model => model.Transfers)
                    .WithOne(t => t.HospitalPractice)
                    .HasForeignKey(t => t.HospitalPracticeId);

                b.HasMany(model => model.DrugPacks)
                    .WithOne(dp => dp.HospitalPractice)
                    .HasForeignKey(dp => dp.HospitalPracticeId);

                b.HasOne(model => model.Practice)
                    .WithMany(p => p.HospitalPractices)
                    .HasForeignKey(model => model.PracticeId);

                b.HasIndex(model => model.PracticeId).IsUnique(false);

                b.HasOne(model => model.FileType)
                    .WithMany(ft => ft.HospitalPractice)
                    .HasForeignKey(model => model.FileTypeId);

                b.HasIndex(model => model.FileTypeId).IsUnique(false);
            });
        }
    }
}