using System;
using System.Threading.Tasks;
using Lib.Cosmos.Apis;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.OpResponses;
using Lib.Cosmos.OpResponses;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace Lib.Cosmos.Adapters;

internal sealed class CosmosContainerDeleteAdapter : ICosmosContainerDeleteAdapter
{
    private readonly ILogger _logger;

    public CosmosContainerDeleteAdapter(ILogger logger) => _logger = logger;

    public async Task<OpResponse<T>> DeleteItemAsync<T>(Container container, T item) where T : CosmosItem
    {
        ItemResponse<T> itemResponse = await container.DeleteItemAsync<T>(item.Id, new PartitionKey(item.Partition)).ConfigureAwait(false);
        _logger.DeleteInformation(itemResponse.RequestCharge, itemResponse.Diagnostics.GetClientElapsedTime());
        return new ItemOpResponse<T>(itemResponse);
    }
}

internal static partial class CosmosContainerUpsertAdapterLoggerExtensions
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "DeleteItem cost: [RequestCharge={requestCharge}] [ElapsedTime={elapsedTime}]")
    ]
    public static partial void DeleteInformation(this ILogger logger, double requestCharge, TimeSpan elapsedTime);
}

