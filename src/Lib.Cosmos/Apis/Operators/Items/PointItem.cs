using Lib.Cosmos.Apis.Primitives;

namespace Lib.Cosmos.Apis.Operators.Items;

public abstract class PointItem
{
    public CosmosItemId Id { get; init; }
    public PartitionKeyValue Partition { get; init; }
}

public sealed class ReadPointItem : PointItem;

public sealed class DeletePointItem : PointItem;
