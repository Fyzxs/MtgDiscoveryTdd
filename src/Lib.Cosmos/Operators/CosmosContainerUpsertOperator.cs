using System;
using System.Threading.Tasks;
using Lib.Cosmos.Apis.Operators;
using Lib.Cosmos.Apis.Operators.Responses;
using Lib.Cosmos.OpResponses;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace Lib.Cosmos.Operators;

internal sealed class CosmosContainerUpsertOperator : ICosmosContainerUpsertOperator
{
    private readonly ILogger _logger;

    public CosmosContainerUpsertOperator(ILogger logger)
    {
        _logger = logger;
    }

    public async Task<OpResponse<T>> UpsertItemAsync<T>(Container container, T item)
    {
        ItemResponse<T> itemResponse = await container.UpsertItemAsync(item).ConfigureAwait(false);
        _logger.UpsertInformation(itemResponse.RequestCharge, itemResponse.Diagnostics.GetClientElapsedTime());
        return new ItemOpResponse<T>(itemResponse);
    }
}

internal static partial class CosmosContainerUpsertAdapterLoggerExtensions
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "UpsertItem cost: [RequestCharge={requestCharge}] [ElapsedTime={elapsedTime}]")
    ]
    public static partial void UpsertInformation(this ILogger logger, double requestCharge, TimeSpan elapsedTime);
}
