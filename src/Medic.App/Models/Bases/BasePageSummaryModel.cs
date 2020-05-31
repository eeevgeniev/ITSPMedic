namespace Medic.App.Models.Bases
{
    public class BasePageSummaryModel : BasePageModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalResults { get; set; }
    }
}
