using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class DrugProtocol
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<DrugProtocol>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.TherapyType)
                    .WithMany(tt => tt.DrugProtocols)
                    .HasForeignKey(model => model.TherapyTypeId);
            });
        }
    }
}
