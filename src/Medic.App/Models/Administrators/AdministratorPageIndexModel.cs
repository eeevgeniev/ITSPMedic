using Medic.App.Models.Administrators.Models;
using Medic.App.Models.Bases;
using System.Collections.Generic;

namespace Medic.App.Models.Administrators
{
    public class AdministratorPageIndexModel : BasePageSummaryModel
    {
        public List<UserViewModel> Users { get; set; }
    }
}
