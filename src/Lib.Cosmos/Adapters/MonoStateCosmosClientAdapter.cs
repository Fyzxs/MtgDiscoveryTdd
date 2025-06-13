using System.Collections.Concurrent;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.Ids;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Adapters;

public sealed class MonoStateCosmosClientAdapter : ICosmosClientAdapter
{
    private static readonly ConcurrentDictionary<string, ICosmosClientAdapter> s_adapters = new();

    private readonly ICosmosClientAdapterFactory _factory;

    public MonoStateCosmosClientAdapter(ICosmosClientAdapterFactory factory) => _factory = factory;

    private ICosmosClientAdapter GetOrCreateAdapter(CosmosAccountName accountName)
    {
        return s_adapters.GetOrAdd(accountName, _ => _factory.Instance(accountName));
    }

    public Container GetContainer(CosmosAccountName accountName, CosmosDatabaseName databaseName, CosmosCollectionName collectionName) => GetOrCreateAdapter(accountName).GetContainer(accountName, databaseName, collectionName);
}
