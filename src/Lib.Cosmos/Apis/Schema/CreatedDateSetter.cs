namespace Lib.Cosmos.Apis.Schema;

public sealed class CreatedDateSetter
{
    public CosmosItem SetCreatedDate(string createdDate)
    {
        return new CosmosItem { CreatedDate = createdDate };
    }
}