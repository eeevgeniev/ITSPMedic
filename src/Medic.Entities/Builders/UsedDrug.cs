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
            });
        }
    }
}