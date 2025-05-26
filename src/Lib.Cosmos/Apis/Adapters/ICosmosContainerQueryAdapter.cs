using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Apis.Adapters;

/// <summary>
/// Defines an adapter interface for querying items from a Cosmos DB container.
/// </summary>
public interface ICosmosContainerQueryAdapter
{
    /// <summary>
    /// Executes a query against the specified Cosmos DB container and returns the results as an enumerable of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items to be returned.</typeparam>
    /// <param name="container">The Cosmos DB container to query.</param>
    /// <param name="queryDefinition">The query definition to execute.</param>
    /// <param name="partitionKey">The partition key to use for the query.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of items of type <typeparamref name="T"/>.</returns>
    Task<IEnumerable<T>> QueryAsync<T>(Container container, QueryDefinition queryDefinition, PartitionKey partitionKey, CancellationToken cancellationToken = default);
