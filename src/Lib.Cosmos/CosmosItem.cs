using Newtonsoft.Json;

namespace Lib.Cosmos;

public class CosmosItem
{
    private string _itemType;

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("partition")]
    public string Partition { get; set; }

    [JsonProperty("item_type")]
    public string ItemType
    {
        get => _itemType ??= GetType().FullName;
        set => _itemType = value;
    }

    public string CreatedDate { get; set; }
}
