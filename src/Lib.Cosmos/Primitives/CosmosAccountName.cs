using Lib.Universal.Primitives;

namespace Lib.Cosmos.Primitives;

public class CosmosAccountName : ToSystemType<string>
{
    public override string AsSystemType() => "potato";
}
