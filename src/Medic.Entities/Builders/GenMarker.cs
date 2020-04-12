using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class GenMarker
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<GenMarker>(b =>
            {
                b.HasKey(model => model.Id);
            });
        }
    }
}