using Lib.Universal.Primitives;

namespace Lib.Cosmos.Primitives;

public abstract class CosmosAccountName : ToSystemType<string>
{
    public override string AsSystemType() => "potato";
}
