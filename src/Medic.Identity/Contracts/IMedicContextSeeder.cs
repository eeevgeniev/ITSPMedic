using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Identity.Contracts
{
    public interface IMedicContextSeeder
    {
        void Seed(List<(string username, string password, string email)> accounts);
    }
}
