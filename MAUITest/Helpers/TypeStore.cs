using MAUITest.Models;

namespace MAUITest.Helpers
{
    public class TypeStore
    {
        private TypeStore()
        {
            typeOperations = new List<TypeOperation>()
            {
                new ProfitOperation(),
                new ExpendOperation()
            };
        }

        private static TypeStore storage = new TypeStore();
        public static TypeStore Storage => storage;

        private IList<TypeOperation> typeOperations;

        public IEnumerable<TypeOperation> GetTypeOperations()
        {
            foreach(var element in typeOperations)
                yield return element;
        }
    }
}
