using System.Threading.Tasks;
using Lib.Cosmos.Apis.Ids;
using Lib.Cosmos.Apis.Operators.Responses;
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

    /// <summary>
    /// Creates a database if it does not exist.
    /// </summary>
    /// <param name="accountName">The name of the Cosmos DB account.</param>
    /// <param name="databaseName">The name of the Cosmos DB database.</param>
    /// <returns>A task representing the asynchronous operation that returns an <see cref="OpResponse{Database}"/>.</returns>
    Task<OpResponse<Database>> CreateDatabaseIfNotExistsAsync(CosmosAccountName accountName, CosmosDatabaseName databaseName);
}
