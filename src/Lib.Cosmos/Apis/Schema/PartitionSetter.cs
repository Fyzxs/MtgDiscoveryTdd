namespace Lib.Cosmos.Apis.Schema;

public sealed class PartitionSetter
{
    public CosmosItem SetPartition(string partition)
    {
        return new CosmosItem { Partition = partition };
    }
}