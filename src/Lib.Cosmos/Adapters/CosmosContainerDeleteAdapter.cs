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

    public async Task<OpResponse<T>> DeleteItemAsync<T>(Container container, CosmosItem cosmosItem)
    {
        await Task.Delay(0).ConfigureAwait(false);
        _logger.DeleteInformation(1234.56, new TimeSpan(0, 12, 34, 56));
        return new ItemOpResponse<T>(null);
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

