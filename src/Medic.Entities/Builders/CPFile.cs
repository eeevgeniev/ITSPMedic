using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class CPFile
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<CPFile>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Practice)
                    .WithMany(p => p.CPFiles)
                    .HasForeignKey(model => model.PracticeId);

                b.HasOne(model => model.FileType)
                    .WithMany(ft => ft.CPFiles)
                    .HasForeignKey(model => model.FileTypeId);

                b.HasMany(model => model.Ins)
                    .WithOne(i => i.CPFile)
                    .HasForeignKey(i => i.CPFileId);

                b.HasMany(model => model.Outs)
                    .WithOne(o => o.CPFile)
                    .HasForeignKey(o => o.CPFileId);

                b.HasMany(model => model.ProtocolDrugTherapies)
                    .WithOne(pdt => pdt.CPFile)
                    .HasForeignKey(pdt => pdt.CPFileId);

                b.HasMany(model => model.Transfers)
                    .WithOne(t => t.CPFile)
                    .HasForeignKey(t => t.CPFileId);

                b.HasMany(model => model.PlannedProcedures)
                    .WithOne(pp => pp.CPFile)
                    .HasForeignKey(pp => pp.CPFileId);
            });
        }
    }
}