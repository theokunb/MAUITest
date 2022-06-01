using Firebase.Database;
using MAUITest.Helpers;
using MAUITest.Models;
using Newtonsoft.Json;

namespace MAUITest.Services
{
    public class RealTimeDB
    {
        private RealTimeDB(string key)
        {
            client = new FirebaseClient(key);
        }


        private static RealTimeDB realTimeDB = new RealTimeDB(Strings.RealTimeDataBaseKey);
        private readonly FirebaseClient client;

        public static RealTimeDB DataBase => realTimeDB;



        public async Task PostOperationAsync(Operation operation)
        {
            string content = JsonConvert.SerializeObject(operation);
            await client.Child(Strings.TableOperations).PostAsync(content);
        }

        public async Task<List<Operation>> GetOperationsAsync(Filter filter = null)
        {
            var collection = (await client.Child(Strings.TableOperations).OnceAsync<Operation>()).Select(element => element.Object).ToList();
            if (filter == null)
                return collection;
            else
            {
                return filter.ApplyFilter(collection);
            }
        }
        
        public async Task<float?> GetAccountAsync()
        {
            var value = await client.Child(Strings.TableAccount).OnceSingleAsync<float?>();
            return value;
        }

        public async Task CreateNewAccountAsync(float startCapital)
        {
            await client.Child(Strings.TableAccount).PutAsync(startCapital.ToString());
        }

        public async Task PatchAccount(float newValue)
        {
            await client.Child(Strings.TableAccount).PatchAsync(newValue.ToString());
        }
    }
}
