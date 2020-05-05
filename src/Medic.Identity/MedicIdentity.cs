using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Medic.Identity
{
    public class MedicIdentity : IdentityDbContext
    {
        public MedicIdentity(DbContextOptions<MedicIdentity> options)
            : base (options)
        {

        }
    }
}