using Lib.Universal.Primitives;

namespace Lib.Cosmos.Apis;

public abstract class CosmosItemResponse<T> : ToSystemType<T>
{
    public virtual T Value { get; }
}
