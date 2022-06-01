using MAUITest.Models;

namespace MAUITest.Helpers
{
    public class FilterStore
    {
        private FilterStore()
        {
            filters = new List<Filter>()
            {
                new FilterWeek(),
                new FilterMonth(),
                new FilterYear()
            };
        }

        private static FilterStore storage = new FilterStore();
        private IList<Filter> filters;

        public static FilterStore Storage => storage;


        public IEnumerable<Filter> GetFilters()
        {
            foreach(var element in filters)
                yield return element;
        }
    }
}
