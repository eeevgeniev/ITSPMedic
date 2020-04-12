using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class CommissionAprHealthcarePractitioner
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<CommissionAprHealthcarePractitioner>(b =>
            {
                b.HasKey(model => new { model.HealthcarePractitionerId, model.CommissionAprId });
            });
        }
    }
}
