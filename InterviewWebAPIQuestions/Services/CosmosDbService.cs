using Microsoft.Azure.Cosmos;

namespace InterviewWebAPIQuestions.Services
{
    public class CosmosDbService
    {
        private Container _container;

        public CosmosDbService(IConfiguration config)
        {
            var cosmosClient = new CosmosClient(config["CosmosDb:AccountEndpoint"], config["CosmosDb:AccountKey"]);
            var database = cosmosClient.GetDatabase(config["CosmosDb:DatabaseName"]);
            _container = database.GetContainer(config["CosmosDb:ContainerName"]);
        }

        public async Task<ItemResponse<T>> GetItemAsync<T>(string id, string partitionKey)
        {
            return await _container.ReadItemAsync<T>(id, new PartitionKey(partitionKey));
        }
    }
}
