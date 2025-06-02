using System.Threading.Tasks;
using Lib.Cosmos.Apis.Operators.Items;
using Lib.Cosmos.Apis.Operators.Responses;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Apis.Operators;

/// <summary>
/// Adapter interface for reading items from a Cosmos DB container.
/// </summary>
public interface ICosmosContainerReadItemOperator
{
    /// <summary>
    /// Reads an item from the specified Cosmos DB container.
    /// </summary>
    /// <typeparam name="T">The type of the item to read.</typeparam>
    /// <param name="container">The Cosmos DB container.</param>
    /// <param name="item">The item to read, containing the necessary identifiers.</param>
    /// <returns>
    /// A task that represents the asynchronous read operation. The task result contains an <see cref="OpResponse{T}"/>
    /// representing the outcome of the read operation.
    /// </returns>
    Task<OpResponse<T>> ReadItemAsync<T>(Container container, ReadPointItem item);
}
