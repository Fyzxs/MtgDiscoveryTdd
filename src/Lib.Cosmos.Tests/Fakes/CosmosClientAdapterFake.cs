using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.Ids;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class CosmosClientAdapterFake : ICosmosClientAdapter
{
    public Container GetContainerResponse { get; set; }
    public int GetContainerInvokeCount { get; private set; }
    public CosmosDatabaseName LastDatabaseName { get; private set; }
    public CosmosCollectionName LastCollectionName { get; private set; }

    public Container GetContainer(CosmosDatabaseName databaseName, CosmosCollectionName collectionName)
    {
        GetContainerInvokeCount++;
        LastDatabaseName = databaseName;
        LastCollectionName = collectionName;
        return GetContainerResponse;
    }
}