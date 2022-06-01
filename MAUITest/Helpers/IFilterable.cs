using MAUITest.Models;

namespace MAUITest.Helpers
{
    public interface IFilterable
    {
        List<Operation> ApplyFilter(List<Operation> operations);
    }
}
