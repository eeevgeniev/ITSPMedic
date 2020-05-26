using System.Collections.Generic;

namespace Medic.AppModels.Contracts
{
    public interface IQueryStringBuilder
    {
        Dictionary<string, string> BuildQuery(string prefix);
    }
}
