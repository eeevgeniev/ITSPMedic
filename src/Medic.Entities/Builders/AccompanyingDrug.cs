using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Medic.Entities
{
    public partial class AccompanyingDrug 
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<AccompanyingDrug>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.TherapyType)
                    .WithMany(tt => tt.AccompanyingDrugs)
                    .HasForeignKey(model => model.TherapyTypeId);

                b.Property(model => model.ATCCode).HasMaxLength(20);

                b.Property(model => model.ATCName).HasMaxLength(200);
            });
        }
    }
}