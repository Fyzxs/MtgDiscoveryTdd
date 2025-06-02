using System.Net;
using Lib.Universal.Primitives;

namespace Lib.Cosmos.Apis.Operators.Responses;

/// <summary>
/// Represents a response from a Cosmos DB item operation.
/// </summary>
/// <typeparam name="T">The type of the item.</typeparam>
public abstract class OpResponse<T> : ToSystemType<T>
{
    /// <summary>
    /// Gets the value of the item.
    /// </summary>
    public abstract T Value { get; }

    /// <summary>
    /// Gets the HTTP status code of the response.
    /// </summary>
    public abstract HttpStatusCode StatusCode { get; }

    /// <summary>
    /// Determines whether the status code indicates a successful response.
    /// </summary>
    /// <returns><c>true</c> if the status code is between 200 and 299; otherwise, <c>false</c>.</returns>
    public bool IsSuccessfulStatusCode() => 200 <= (int)StatusCode && (int)StatusCode <= 299;

    /// <summary>
    /// Determines whether the status code indicates an unsuccessful response.
    /// </summary>
    /// <returns><c>true</c> if the status code is not between 200 and 299; otherwise, <c>false</c>.</returns>
    public bool IsNotSuccessfulStatusCode() => IsSuccessfulStatusCode() is false;

    /// <summary>
    /// Converts the response to its system type representation.
    /// </summary>
    /// <returns>The value of the item.</returns>
    public override T AsSystemType() => Value;
}
