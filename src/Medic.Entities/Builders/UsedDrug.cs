using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class UsedDrug
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<UsedDrug>(b =>
            {
                b.HasKey(model => model.Id);

                b.Property(model => model.Code).HasMaxLength(10);

                b.Property(model => model.ICDDrug).HasMaxLength(10);

                b.Property(model => model.UINPrescr).HasMaxLength(10);

                b.Property(model => model.NoPrescr).HasMaxLength(10);

                b.Property(model => model.PracticeCodeProtocol).HasMaxLength(12);
            });
        }
    }
}