using System.Net;
using Lib.Cosmos.Apis.Operators.Responses;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class DatabaseOpResponseFake : OpResponse<Database>
{
    public Database ValueToReturn { get; init; }
    public HttpStatusCode StatusCodeToReturn { get; init; }

    public override Database Value => ValueToReturn;
    public override HttpStatusCode StatusCode => StatusCodeToReturn;
}