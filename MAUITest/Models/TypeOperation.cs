namespace MAUITest.Models
{
    public abstract class TypeOperation
    {
        public string Title { get; set; }
    }


    public class ProfitOperation : TypeOperation
    {
        public ProfitOperation()
        {
            Title = "Доход";
        }
    }

    public class ExpendOperation : TypeOperation
    {
        public ExpendOperation()
        {
            Title = "Расход";
        }
    }
}
