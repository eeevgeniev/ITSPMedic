using Microsoft.EntityFrameworkCore;

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
            });
        }
    }
}