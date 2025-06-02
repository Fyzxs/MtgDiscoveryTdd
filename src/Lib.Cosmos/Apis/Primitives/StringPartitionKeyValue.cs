using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Apis.Primitives;

public sealed class StringPartitionKeyValue : PartitionKeyValue
{
    private readonly string _source;

    public StringPartitionKeyValue(string source) => _source = source;

    public override PartitionKey AsSystemType() => new(_source);
}
