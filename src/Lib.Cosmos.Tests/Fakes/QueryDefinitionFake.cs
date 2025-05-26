using Lib.Cosmos.Apis.Queries;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class QueryDefinitionFake : SimpleQueryDefinition
{
    public override QueryDefinition AsSystemType() => new("fake query");
}