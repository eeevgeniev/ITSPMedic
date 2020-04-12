using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class ProtocolDrugTherapyHealthPractitioner
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<ProtocolDrugTherapyHealthPractitioner>(b =>
            {
                b.HasKey(model => new { model.HealthcarePractitionerId, model.ProtocolDrugTherapyId });
            });
        }
    }
}