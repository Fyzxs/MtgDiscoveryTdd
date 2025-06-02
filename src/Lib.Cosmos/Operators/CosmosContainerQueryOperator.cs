using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lib.Cosmos.Apis.Operators;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace Lib.Cosmos.Operators;

internal sealed class CosmosContainerQueryOperator : ICosmosContainerQueryOperator
{
    private readonly ILogger _logger;

    public CosmosContainerQueryOperator(ILogger logger)
    {
        _logger = logger;
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(Container container, QueryDefinition queryDefinition, PartitionKey partitionKey, CancellationToken cancellationToken = default)
    {
        FeedIterator<T> iterator = container.GetItemQueryIterator<T>(queryDefinition);
        List<T> collection = [];

        while (iterator.HasMoreResults)
        {
            FeedResponse<T> response = await iterator.ReadNextAsync(cancellationToken).ConfigureAwait(false);
            _logger.QueryInformation(response.RequestCharge, response.Diagnostics.GetClientElapsedTime());
            collection.AddRange(response.Resource);
        }

        return collection;
    }
}

internal static partial class CosmosContainerQueryAdapterLoggerExtensions
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "GetItemQueryIterator cost: [RequestCharge={requestCharge}] [ElapsedTime={elapsedTime}]")
    ]
    public static partial void QueryInformation(this ILogger logger, double requestCharge, TimeSpan elapsedTime);
}
