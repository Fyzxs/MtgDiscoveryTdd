using Newtonsoft.Json;

namespace Lib.Cosmos;

public class CosmosItem
{
    [JsonProperty("id")]
    public string Id { get; set; }
}
