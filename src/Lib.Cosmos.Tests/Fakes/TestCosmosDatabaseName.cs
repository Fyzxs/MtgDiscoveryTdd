using Lib.Cosmos.Apis.Ids;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class TestCosmosDatabaseName : CosmosDatabaseName
{
    private readonly string _value;

    public TestCosmosDatabaseName(string value) => _value = value;

    public override string AsSystemType() => _value;
}