using System;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class CosmosDiagnosticsFake : CosmosDiagnostics
{
    public TimeSpan GetClientElapsedTimeResult { get; set; }
    public override TimeSpan GetClientElapsedTime() => GetClientElapsedTimeResult;

    public override string ToString() => throw new NotImplementedException();

    public override IReadOnlyList<(string regionName, Uri uri)> GetContactedRegions() => throw new NotImplementedException();
}