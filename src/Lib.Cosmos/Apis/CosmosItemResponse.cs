using Lib.Universal.Primitives;

namespace Lib.Cosmos.Apis;

public abstract class CosmosItemResponse<T> : ToSystemType<T>
{
    public T Value { get; set; }
}
