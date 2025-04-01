using System.Net;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class ItemResponseFake : ItemResponse<object>
{
    public object ResourceResult { get; init; }
    public HttpStatusCode StatusCodeResult { get; init; }

    public override object Resource => ResourceResult;
    public override HttpStatusCode StatusCode => StatusCodeResult;
}