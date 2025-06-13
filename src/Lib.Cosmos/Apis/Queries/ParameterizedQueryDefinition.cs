using System.Collections.Generic;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Apis.Queries;

public abstract class ParameterizedQueryDefinition : SimpleQueryDefinition
{
    private readonly SimpleQueryDefinition _queryDefinition;
    private readonly Dictionary<string, string> _params;

    protected ParameterizedQueryDefinition(SimpleQueryDefinition queryDefinition) : this(queryDefinition, []) { }

    private ParameterizedQueryDefinition(SimpleQueryDefinition queryDefinition, Dictionary<string, string> @params)
    {
        _queryDefinition = queryDefinition;
        _params = @params;
    }

    public ParameterizedQueryDefinition WithParameter(string key, string value)
    {
        _params.Add(key, value);

        return this;
    }

    public override QueryDefinition AsSystemType()
    {
        QueryDefinition queryDefinition = _queryDefinition.AsSystemType();

        foreach (KeyValuePair<string, string> param in _params)
        {
            queryDefinition.WithParameter(param.Key, param.Value);
        }

        return queryDefinition;
    }
}
