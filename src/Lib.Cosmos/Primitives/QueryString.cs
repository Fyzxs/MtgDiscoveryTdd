using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Primitives;

public sealed class QueryString : SimpleQueryDefinition
{
    private readonly string _origin;

    public QueryString(string origin) => _origin = origin;

    public override QueryDefinition AsSystemType() => new(_origin);
}
