using System;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;

namespace Lib.Cosmos.Apis;

public abstract class PointItem
{
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    [JsonProperty("partition")]
    public virtual string Partition { get; set; }

    public PartitionKey AsPartitionKey() => new(Partition);
}

public /* cosmos required */ class CosmosItem : PointItem
{
    private string _itemType;

    [JsonProperty("item_type")]
    public string ItemType
    {
        get => _itemType ??= GetType().FullName;
        set => _itemType = value;
    }

    [JsonProperty("created_date")]
    public string CreatedDate { get; set; } = DateTime.UtcNow.ToString("o");
}

public sealed class ReadPointItem : PointItem;

public sealed class DeletePointItem : PointItem;
