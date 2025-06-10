using System.Threading;
using System.Threading.Tasks;

namespace Lib.Cosmos.Apis;

/// <summary>
/// Defines the public contract used by all Genesis-Device variants.
/// </summary>
public interface IGenesisDevice
{
    /// <summary>
    /// Ensures that the Cosmos DB container exists.
    /// </summary>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task EnsureContainerAsync(CancellationToken cancellationToken = default);
}