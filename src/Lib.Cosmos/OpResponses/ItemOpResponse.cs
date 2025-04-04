using System.Net;
using Lib.Cosmos.Apis;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.OpResponses;

public sealed class ItemOpResponse<T> : OpResponse<T>
{
    public ItemOpResponse(ItemResponse<T> itemResponse)
    {
    }

    public override T Value => throw new System.NotImplementedException();

    public override HttpStatusCode StatusCode => throw new System.NotImplementedException();
}