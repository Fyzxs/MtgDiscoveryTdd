using System;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.Ids;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace Lib.Cosmos.Adapters;

public sealed class CosmosClientAdapter : ICosmosClientAdapter
{
    private readonly CosmosClient _cosmosClient;
    private readonly ILogger _logger;

    public CosmosClientAdapter(CosmosClient cosmosClient, ILogger logger)
    {
        _cosmosClient = cosmosClient;
        _logger = logger;
    }

    public Container GetContainer(CosmosAccountName accountName, CosmosDatabaseName databaseName, CosmosCollectionName collectionName)
    {
        _logger.GetContainerInformation(accountName, databaseName, collectionName);
        Database database = _cosmosClient.GetDatabase(databaseName);
        return database.GetContainer(collectionName);
    }
}

internal static partial class CosmosClientAdapterLoggerExtensions
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Getting container: [AccountName={accountName}] [DatabaseName={databaseName}] [CollectionName={collectionName}]")
    ]
    public static partial void GetContainerInformation(this ILogger logger, CosmosAccountName accountName, CosmosDatabaseName databaseName, CosmosCollectionName collectionName);
}
