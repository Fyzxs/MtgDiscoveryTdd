using System;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.Ids;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace Lib.Cosmos.Adapters;

public sealed class CosmosClientAdapterFactory : ICosmosClientAdapterFactory
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger _logger;

    public CosmosClientAdapterFactory(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<CosmosClientAdapterFactory>();
    }

    public ICosmosClientAdapter Instance(CosmosAccountName accountName)
    {
        _logger.CreatingInstanceInformation(accountName);
        string endpoint = $"https://{accountName}.documents.azure.com:443/";
        string key = Environment.GetEnvironmentVariable("COSMOS_DB_KEY");

        if (string.IsNullOrEmpty(key))
        {
            _logger.MissingEnvironmentVariableError();
            throw new InvalidOperationException("COSMOS_DB_KEY environment variable is required but not set.");
        }

        CosmosClient cosmosClient = new(endpoint, key);
        ILogger adapterLogger = _loggerFactory.CreateLogger<CosmosClientAdapter>();

        return new CosmosClientAdapter(cosmosClient, adapterLogger);
    }
}

internal static partial class CosmosClientAdapterFactoryLoggerExtensions
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Creating CosmosClientAdapter instance for account: [AccountName={accountName}]")
    ]
    public static partial void CreatingInstanceInformation(this ILogger logger, CosmosAccountName accountName);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "COSMOS_DB_KEY environment variable is required but not set")
    ]
    public static partial void MissingEnvironmentVariableError(this ILogger logger);
}
