using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.Ids;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class CosmosClientAdapterFake : ICosmosClientAdapter
{
    public Container GetContainerResponse { get; init; }
    public int GetContainerInvokeCount { get; private set; }
    public CosmosAccountName LastAccountName { get; private set; }

    public Container GetContainer(CosmosAccountName accountName, CosmosDatabaseName databaseName, CosmosCollectionName collectionName)
    {
        GetContainerInvokeCount++;
        LastAccountName = accountName;
        return GetContainerResponse;
    }
}
