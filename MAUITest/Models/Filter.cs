using MAUITest.Helpers;

namespace MAUITest.Models
{
    public abstract class Filter : IFilterable
    {
        protected string title;

        public string Title => title;


        protected Func<Operation,bool> predicate;

        public List<Operation> ApplyFilter(List<Operation> operations)
        {
            return operations.Where(predicate).ToList();
        }
        
    }

    public class FilterWeek : Filter
    {
        public FilterWeek()
        {
            title = "за неделю";
            predicate = new Func<Operation, bool>((oper) =>
            {
                if (DateTime.Now - oper.DateOperation < new TimeSpan(7, 0, 0, 0))
                    return true;
                return false;
            });
        }

    }

    public class FilterMonth : Filter, IFilterable
    {
        public FilterMonth()
        {
            title = "за месяц";
            predicate = new Func<Operation, bool>((oper) =>
            {
                if (DateTime.Now - oper.DateOperation < new TimeSpan(30, 0, 0, 0))
                    return true;
                return false;
            });
        }

    }

    public class FilterYear : Filter, IFilterable
    {
        public FilterYear()
        {
            title = "за год";
            predicate = new Func<Operation, bool>((oper) =>
            {
                if (DateTime.Now - oper.DateOperation < new TimeSpan(365, 0, 0, 0))
                    return true;
                return false;
            });
        }
    }
}
