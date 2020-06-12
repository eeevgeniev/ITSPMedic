using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class DrugResidue
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<DrugResidue>(b =>
            {
                b.HasKey(model => model.Id);

                b.Property(model => model.DrugCode).HasMaxLength(10);

                b.Property(model => model.ProductCode).HasMaxLength(20);

                b.Property(model => model.BatchNumber).HasMaxLength(20);

                b.Property(model => model.SerialNumber).HasMaxLength(20);

                b.Property(model => model.Quantity).HasColumnType("decimal(15,4)");

                b.Property(model => model.DrugCost).HasColumnType("decimal(15,4)");

                b.HasIndex(model => model.HospitalPracticeId).IsUnique(false);

                b.HasIndex(model => model.CPFileId).IsUnique(false);
            });
        }
    }
}
