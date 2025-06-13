namespace Lib.Cosmos.Apis.Schema;

public sealed class IdSetter
{
    public CosmosItem SetId(string id)
    {
        return new CosmosItem { Id = id };
    }
}