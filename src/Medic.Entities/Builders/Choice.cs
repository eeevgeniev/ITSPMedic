using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Choice
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Choice>(b =>
            {
                b.HasKey(model => model.Id);

                b.Property(model => model.Text).HasMaxLength(1000);

                b.HasIndex(model => model.EvaluationId).IsUnique(false);
            });
        }
    }
}