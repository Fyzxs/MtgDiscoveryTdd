namespace Lib.Cosmos.Apis.Schema;

public sealed class ItemTypeSetter
{
    public CosmosItem SetItemType(string itemType)
    {
        return new CosmosItem { ItemType = itemType };
    }
}