using System.Threading.Tasks;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.Ids;
using Lib.Cosmos.Apis.Operators.Responses;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class CosmosClientAdapterFake : ICosmosClientAdapter
{
    public Container GetContainerResponse { get; init; }
    public int GetContainerInvokeCount { get; private set; }
    public CosmosAccountName LastAccountName { get; private set; }

    public OpResponse<Database> CreateDatabaseIfNotExistsAsyncResponse { get; init; }
    public int CreateDatabaseIfNotExistsAsyncInvokeCount { get; private set; }
    public CosmosDatabaseName LastDatabaseName { get; private set; }

    public Container GetContainer(CosmosAccountName accountName, CosmosDatabaseName databaseName, CosmosCollectionName collectionName)
    {
        GetContainerInvokeCount++;
        LastAccountName = accountName;
        return GetContainerResponse;
    }

    public Task<OpResponse<Database>> CreateDatabaseIfNotExistsAsync(CosmosAccountName accountName, CosmosDatabaseName databaseName)
    {
        CreateDatabaseIfNotExistsAsyncInvokeCount++;
        LastAccountName = accountName;
        LastDatabaseName = databaseName;
        return Task.FromResult(CreateDatabaseIfNotExistsAsyncResponse);
    }
}
