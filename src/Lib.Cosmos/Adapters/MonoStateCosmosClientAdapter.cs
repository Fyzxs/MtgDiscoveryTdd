using System.Collections.Generic;
using System.Threading;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.Ids;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Adapters;

public sealed class MonoStateCosmosClientAdapter : ICosmosClientAdapter
{
    private static readonly Dictionary<string, ICosmosClientAdapter> s_adapters = new();
    private static readonly SemaphoreSlim s_semaphore = new(1, 1);

    private readonly ICosmosClientAdapterFactory _factory;

    public MonoStateCosmosClientAdapter(ICosmosClientAdapterFactory factory) => _factory = factory;

    private ICosmosClientAdapter MonoState(CosmosAccountName accountName)
    {
        string accountKey = accountName.AsSystemType();

        if (s_adapters.TryGetValue(accountKey, out ICosmosClientAdapter adapter))
        {
            return adapter;
        }

        s_semaphore.Wait();
        try
        {
            if (s_adapters.TryGetValue(accountKey, out adapter))
            {
                return adapter;
            }

            adapter = _factory.Instance(accountName);
            s_adapters[accountKey] = adapter;
            return adapter;
        }
        finally
        {
            _ = s_semaphore.Release();
        }
    }

    public Container GetContainer(CosmosAccountName accountName, CosmosDatabaseName databaseName, CosmosCollectionName collectionName) => MonoState(accountName).GetContainer(accountName, databaseName, collectionName);
}