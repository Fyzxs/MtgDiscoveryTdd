using Lib.Cosmos.Apis.Ids;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class TestCosmosCollectionName : CosmosCollectionName
{
    private readonly string _value;

    public TestCosmosCollectionName(string value) => _value = value;

    public override string AsSystemType() => _value;
}