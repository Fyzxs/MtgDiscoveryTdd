using System;
using System.Threading.Tasks;
using Lib.Cosmos.Apis;
using Lib.Cosmos.Apis.Operators;
using Lib.Cosmos.Apis.Operators.Responses;
using Lib.Cosmos.OpResponses;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace Lib.Cosmos.Operators;

public sealed class CosmosContainerReadItemOperator : ICosmosContainerReadItemOperator
{
    private readonly ILogger _logger;

    public CosmosContainerReadItemOperator(ILogger logger)
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
