using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.Ids;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Adapters;

public sealed class CosmosClientAdapter : ICosmosClientAdapter
{
    private readonly CosmosClient _cosmosClient;

    public CosmosClientAdapter(CosmosClient cosmosClient) => _cosmosClient = cosmosClient;

    public Container GetContainer(CosmosAccountName accountName, CosmosDatabaseName databaseName, CosmosCollectionName collectionName)
    {
        Database database = _cosmosClient.GetDatabase(databaseName);
        return database.GetContainer(collectionName);
    }
}
