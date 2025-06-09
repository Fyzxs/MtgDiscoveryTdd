using Lib.Cosmos.Apis.Ids;

namespace Lib.Cosmos.Apis.Adapters;

/// <summary>
/// Factory interface for creating instances of <see cref="ICosmosClientAdapter"/>.
/// </summary>
public interface ICosmosClientAdapterFactory
{
    /// <summary>
    /// Creates an instance of <see cref="ICosmosClientAdapter"/>.
    /// </summary>
    /// <param name="accountName">The name of the Cosmos DB account.</param>
    /// <returns>An instance of <see cref="ICosmosClientAdapter"/>.</returns>
    ICosmosClientAdapter Instance(CosmosAccountName accountName);
}
