﻿using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Lib.Cosmos.Apis;
using Lib.Cosmos.OpResponses;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace Lib.Cosmos.Adapters;

public sealed class CosmosContainerUpsertAdapter : ICosmosContainerUpsertAdapter
{
    public CosmosContainerUpsertAdapter(ILogger logger)
    {
    }

    public async Task<OpResponse<T>> UpsertItemAsync<T>([NotNull] Container container, T item)
    {
        ItemResponse<T> itemResponse = await container.UpsertItemAsync(item).ConfigureAwait(false);

        return new ItemOpResponse<T>(itemResponse);
    }
}
