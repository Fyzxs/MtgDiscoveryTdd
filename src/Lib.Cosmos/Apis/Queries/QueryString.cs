using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Apis.Queries;

public sealed class QueryString : SimpleQueryDefinition
{
    private readonly string _origin;

    public QueryString(string origin) => _origin = origin;

    public override QueryDefinition AsSystemType() => new(_origin);
}
