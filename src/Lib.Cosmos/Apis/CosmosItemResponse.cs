using System.Net;
using Lib.Universal.Primitives;

namespace Lib.Cosmos.Apis;

public abstract class CosmosItemResponse<T> : ToSystemType<T>
{
    public abstract T Value { get; }
    public abstract HttpStatusCode StatusCode { get; }

    public bool IsSuccessfulStatusCode()
    {
        return false;
    }
}
