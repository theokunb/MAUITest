using MAUITest.Models;

namespace MAUITest.Helpers
{
    public class CategoryStore
    {
        private CategoryStore()
        {
            categories = new List<Category>()
            {
                new Category()
                {
                    Title = "Дивиденды",
                    Type = new ProfitOperation()
                },
                new Category()
                {
                    Title = "Транспорт",
                    Type = new ExpendOperation()
                },
                new Category()
                {
                    Title = "Возврат долга",
                    Type = new ProfitOperation()
                },
                new Category()
                {
                    Title = "Заработная плата",
                    Type = new ProfitOperation()
                },
                new Category()
                {
                    Title = "Развлечения",
                    Type = new ExpendOperation()
                }
            };
        }

        private static CategoryStore storage = new CategoryStore();

        public static CategoryStore Storage => storage;


        private IList<Category> categories;


        public IEnumerable<Category> GetCategoties(TypeOperation type)
        {
            foreach(var element in categories)
            {
                if (element.Type.Title == type.Title)
                    yield return element;
            }
        }
    }
}
