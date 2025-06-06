namespace Lib.Cosmos.Apis.Adapters;

/// <summary>
/// Factory interface for creating instances of <see cref="ICosmosClientAdapter"/>.
/// </summary>
public interface ICosmosClientAdapterFactory
{
    /// <summary>
    /// Creates an instance of <see cref="ICosmosClientAdapter"/>.
    /// </summary>
    /// <returns>An instance of <see cref="ICosmosClientAdapter"/>.</returns>
    ICosmosClientAdapter Instance();
}
