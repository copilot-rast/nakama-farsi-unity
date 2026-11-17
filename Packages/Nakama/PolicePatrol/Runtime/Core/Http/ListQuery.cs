using System.Collections.Generic;

namespace PolicePatrol.Sdk
{
    public sealed record ListQuery(int PageNum = 1, int LimitItem = 10, string SearchInput = null, string Sort = null, string Order = null)
    {
        public const string Ascending = "asc";
        public const string Descending = "desc";

        public static ListQuery Page(int pageNum, int limitItem = 10) => new ListQuery(pageNum, limitItem);

        public IEnumerable<(string Name, object Value)> Parameters()
        {
            yield return ("searchInput", SearchInput);
            yield return ("sort", Sort);
            yield return ("order", Order);
            yield return ("pageNum", PageNum);
            yield return ("limitItem", LimitItem);
        }
    }
}
