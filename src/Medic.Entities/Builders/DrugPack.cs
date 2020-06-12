using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class DrugPack
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<DrugPack>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasIndex(model => model.CPFileId).IsUnique(false);

                b.HasIndex(model => model.HospitalPracticeId).IsUnique(false);

                b.Property(model => model.DrugCode).HasMaxLength(10);

                b.Property(model => model.BatchNumber).HasMaxLength(30);

                b.Property(model => model.ProductCode).HasMaxLength(20);

                b.Property(model => model.SerialNumber).HasMaxLength(20);

                b.Property(model => model.ExpireDateAsString).HasMaxLength(6);

                b.Property(model => model.DrugQuantity).HasColumnType("decimal(15,4)");
            });
        }
    }
}
