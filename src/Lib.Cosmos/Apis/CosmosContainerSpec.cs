namespace Lib.Cosmos.Apis;

/// <summary>
/// Specification for a Cosmos DB container, holding database name, container name, and optional configuration.
/// </summary>
public sealed class CosmosContainerSpec
{
    /// <summary>
    /// Gets or sets the name of the Cosmos DB database.
    /// </summary>
    public string DatabaseName { get; set; }

    /// <summary>
    /// Gets or sets the name of the Cosmos DB container.
    /// </summary>
    public string ContainerName { get; set; }

    /// <summary>
    /// Gets or sets the optional partition key for the container.
    /// </summary>
    public string PartitionKey { get; set; }

    /// <summary>
    /// Gets or sets the optional throughput for the container.
    /// </summary>
    public int? Throughput { get; set; }
}