namespace Medic.App.Controllers.Base
{
    public abstract class PageBasedController : FormatterBaseController
    {
        protected virtual int GetStartIndex(int length, int page) => 
            page > 0 ? (page - 1) * length : 0;

        protected virtual int TotalPages(int length, int totalCount) =>
            totalCount % length != 0 ? (totalCount / length) + 1 : totalCount / length;
    }
}
