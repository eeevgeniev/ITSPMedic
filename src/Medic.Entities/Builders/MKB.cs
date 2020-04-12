using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class MKB
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<MKB>(b =>
            {
                b.HasKey(model => model.Code);
            });
        }
    }
}