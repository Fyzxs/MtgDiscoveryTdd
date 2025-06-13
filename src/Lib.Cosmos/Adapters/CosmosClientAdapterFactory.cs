using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.Ids;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Adapters;

public sealed class CosmosClientAdapterFactory : ICosmosClientAdapterFactory
{
    public ICosmosClientAdapter Instance(CosmosAccountName accountName)
    {
        string endpoint = $"https://{accountName}.documents.azure.com:443/";
        string key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        CosmosClient cosmosClient = new(endpoint, key);

        return new CosmosClientAdapter(cosmosClient);
    }
}
