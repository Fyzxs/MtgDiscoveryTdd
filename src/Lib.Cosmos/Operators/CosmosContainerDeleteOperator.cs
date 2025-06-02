using System;
using System.Threading.Tasks;
using Lib.Cosmos.Apis.Operators;
using Lib.Cosmos.Apis.Operators.Items;
using Lib.Cosmos.Apis.Operators.Responses;
using Lib.Cosmos.OpResponses;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace Lib.Cosmos.Operators;

internal sealed class CosmosContainerDeleteOperator : ICosmosContainerDeleteOperator
{
    private readonly ILogger _logger;

    public CosmosContainerDeleteOperator(ILogger logger) => _logger = logger;

    public async Task<OpResponse<T>> DeleteItemAsync<T>(Container container, DeletePointItem item)
    {
        ItemResponse<T> itemResponse = await container.DeleteItemAsync<T>(item.Id, item.Partition).ConfigureAwait(false);
        _logger.DeleteInformation(itemResponse.RequestCharge, itemResponse.Diagnostics.GetClientElapsedTime());
        return new ItemOpResponse<T>(itemResponse);
    }
}

internal static partial class CosmosContainerDeleteAdapterLoggerExtensions
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "DeleteItem cost: [RequestCharge={requestCharge}] [ElapsedTime={elapsedTime}]")
    ]
    public static partial void DeleteInformation(this ILogger logger, double requestCharge, TimeSpan elapsedTime);
}
