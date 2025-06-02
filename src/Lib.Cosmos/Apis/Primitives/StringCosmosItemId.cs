namespace Lib.Cosmos.Apis.Primitives;

public sealed class StringCosmosItemId : CosmosItemId
{
    private readonly string _origin;

    public StringCosmosItemId(string origin) => _origin = origin;
    public override string AsSystemType() => _origin;
}