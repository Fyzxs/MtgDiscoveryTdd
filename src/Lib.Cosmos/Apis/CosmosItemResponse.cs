namespace Lib.Cosmos.Apis;

public abstract class CosmosItemResponse<T>
{
    public T Value { get; set; }
}
