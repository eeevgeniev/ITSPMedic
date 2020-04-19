namespace Medic.App.Models.Bases
{
    public abstract class BasePageModel
    {
        public string Title { get; set; }

        public string Keywords { get; set; }

        public string Description { get; set; }

        public string Error { get; set; } = null;
    }
}
