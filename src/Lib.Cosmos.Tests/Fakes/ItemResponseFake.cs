using System.Net;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class ItemResponseFake<T> : ItemResponse<T>
{
    public T ResourceResult { get; init; }
    public HttpStatusCode StatusCodeResult { get; init; }
    public double RequestChargeResult { get; init; }
    public CosmosDiagnostics DiagnosticsResult { get; init; }

    public override T Resource => ResourceResult;
    public override HttpStatusCode StatusCode => StatusCodeResult;
    public override double RequestCharge => RequestChargeResult;

    public override CosmosDiagnostics Diagnostics => DiagnosticsResult;
}
