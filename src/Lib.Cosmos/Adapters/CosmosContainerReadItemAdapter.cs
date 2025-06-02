using System;
using System.Threading.Tasks;
using Lib.Cosmos.Apis;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.OpResponses;
using Lib.Cosmos.OpResponses;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace Lib.Cosmos.Adapters;

public sealed class CosmosContainerReadItemAdapter : ICosmosContainerReadItemAdapter
{
    private readonly ILogger _logger;

    public CosmosContainerReadItemAdapter(ILogger logger)
    {
        _logger = logger;
    }

    public async Task<OpResponse<T>> ReadItemAsync<T>(Container container, ReadPointItem item)
    {
        ItemResponse<T> itemResponse = await container.ReadItemAsync<T>(item.Id, item.AsPartitionKey()).ConfigureAwait(false);
        _logger.ReadItemInformation(itemResponse.RequestCharge, itemResponse.Diagnostics.GetClientElapsedTime());
        return new ItemOpResponse<T>(itemResponse);
    }
}

internal static partial class CosmosContainerReadItemAdapterLoggerExtensions
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "ReadItem cost: [RequestCharge={requestCharge}] [ElapsedTime={elapsedTime}]")
    ]
    public static partial void ReadItemInformation(this ILogger logger, double requestCharge, TimeSpan elapsedTime);
}
