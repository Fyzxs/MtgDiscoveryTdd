using System;
using Newtonsoft.Json;

namespace Lib.Cosmos;

public /* cosmos required */ class CosmosItem
{
    private string _itemType;

    [JsonProperty("id")]
    public virtual string Id { get; set; }

    [JsonProperty("partition")]
    public virtual string Partition { get; set; }

    [JsonProperty("item_type")]
    public string ItemType
    {
        get => _itemType ??= GetType().FullName;
        set => _itemType = value;
    }

    [JsonProperty("created_date")]
    public string CreatedDate { get; set; } = DateTime.UtcNow.ToString("o");
}
