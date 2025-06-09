using Lib.Cosmos.Apis.Ids;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Apis.Adapters;

/// <summary>
/// Adapter interface for interacting with a Cosmos DB client.
/// </summary>
public interface ICosmosClientAdapter
{
    /// <summary>
    /// Gets a Cosmos DB container.
    /// </summary>
    /// <param name="accountName">The name of the Cosmos DB account.</param>
    /// <param name="databaseName">The name of the Cosmos DB database.</param>
    /// <param name="collectionName">The name of the Cosmos DB collection (container).</param>
    /// <returns>The <see cref="Container"/> instance.</returns>
    Container GetContainer(CosmosAccountName accountName, CosmosDatabaseName databaseName, CosmosCollectionName collectionName);
}
