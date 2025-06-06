using System.Threading;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.Ids;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Adapters;

public sealed class MonoStateCosmosClientAdapter : ICosmosClientAdapter
{
    private static ICosmosClientAdapter s_adapter;
    private static readonly SemaphoreSlim s_semaphore = new(1, 1);

    private readonly ICosmosClientAdapterFactory _factory;

    public MonoStateCosmosClientAdapter(ICosmosClientAdapterFactory factory) => _factory = factory;

    // Internal method for testing purposes to reset static state
    internal static void ResetForTesting()
    {
        s_semaphore.Wait();
        try
        {
            s_adapter = null;
        }
        finally
        {
            _ = s_semaphore.Release();
        }
    }

    private ICosmosClientAdapter MonoState()
    {
        if (s_adapter is not null) return s_adapter;

        s_semaphore.Wait();
        try
        {
#pragma warning disable CA1508 // Avoid dead conditional code; it thinks it's always null
            return s_adapter ??= _factory.Instance();
#pragma warning restore CA1508
        }
        finally
        {
            _ = s_semaphore.Release();
        }
    }

    public Container GetContainer(CosmosDatabaseName databaseName, CosmosCollectionName collectionName) => MonoState().GetContainer(databaseName, collectionName);
}