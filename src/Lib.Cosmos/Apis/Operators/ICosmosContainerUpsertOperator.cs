using System.Threading.Tasks;
using Lib.Cosmos.Apis.Operators.Responses;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Apis.Operators;

/// <summary>
/// Defines an adapter interface for upserting items into a Cosmos DB container.
/// </summary>
public interface ICosmosContainerUpsertOperator
{
    /// <summary>
    /// Upserts (inserts or updates) an item in the specified Cosmos DB container.
    /// </summary>
    /// <typeparam name="T">The type of the item to upsert.</typeparam>
    /// <param name="container">The Cosmos DB container where the item will be upserted.</param>
    /// <param name="item">The item to upsert.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an <see cref="OpResponse{T}"/>
    /// representing the outcome of the upsert operation.
    /// </returns>
    Task<OpResponse<T>> UpsertItemAsync<T>(Container container, T item);
}
