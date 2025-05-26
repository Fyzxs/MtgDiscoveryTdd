using Lib.Universal.Primitives;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Primitives;

public sealed class QueryString : ToSystemType<QueryDefinition>
{
    private readonly string _origin;

    public QueryString(string origin) => _origin = origin;

    public override QueryDefinition AsSystemType() => new(_origin);
}