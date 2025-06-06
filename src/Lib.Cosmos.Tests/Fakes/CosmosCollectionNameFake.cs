using Lib.Cosmos.Apis.Ids;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class CosmosCollectionNameFake : CosmosCollectionName
{
    private readonly string _value;

    public CosmosCollectionNameFake(string value) => _value = value;

    public override string AsSystemType() => _value;
}