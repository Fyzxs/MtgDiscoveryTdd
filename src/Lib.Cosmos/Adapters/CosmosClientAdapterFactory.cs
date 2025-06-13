using System;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.Ids;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Adapters;

public sealed class CosmosClientAdapterFactory : ICosmosClientAdapterFactory
{
    public ICosmosClientAdapter Instance(CosmosAccountName accountName)
    {
        string endpoint = $"https://{accountName}.documents.azure.com:443/";
        string key = Environment.GetEnvironmentVariable("COSMOS_DB_KEY");

        if (string.IsNullOrEmpty(key))
        {
            throw new InvalidOperationException("COSMOS_DB_KEY environment variable is required but not set.");
        }

        CosmosClient cosmosClient = new(endpoint, key);

        return new CosmosClientAdapter(cosmosClient);
    }
}
