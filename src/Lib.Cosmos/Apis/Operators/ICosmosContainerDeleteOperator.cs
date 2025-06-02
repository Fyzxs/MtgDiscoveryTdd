using System.Threading.Tasks;
using Lib.Cosmos.Apis.Operators.Items;
using Lib.Cosmos.Apis.Operators.Responses;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Apis.Operators;

/// <summary>
/// Adapter interface for deleting items from a Cosmos DB container.
/// </summary>
internal interface ICosmosContainerDeleteOperator
{
    /// <summary>
    /// Deletes an item from the specified Cosmos DB container.
    /// </summary>
    /// <typeparam name="T">The type of the item to delete.</typeparam>
    /// <param name="container">The Cosmos DB container.</param>
    /// <param name="item">The item to delete, containing the necessary identifiers.</param>
    /// <returns>
    /// A task that represents the asynchronous delete operation. The task result contains an <see cref="OpResponse{T}"/>
    /// representing the outcome of the delete operation.
    /// </returns>
    Task<OpResponse<T>> DeleteItemAsync<T>(Container container, DeletePointItem item);
}
