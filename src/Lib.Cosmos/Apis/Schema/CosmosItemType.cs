using HotChocolate.Types;

namespace Lib.Cosmos.Apis.Schema;

public sealed class CosmosItemType : ObjectType<CosmosItem>
{
    protected override void Configure(IObjectTypeDescriptor<CosmosItem> descriptor)
    {
        descriptor.Name("CosmosItem");
        descriptor.Description("A Cosmos DB item with standard properties");

        descriptor.Field(x => x.Id)
            .Description("The unique identifier of the item");

        descriptor.Field(x => x.Partition)
            .Description("The partition key of the item");

        descriptor.Field(x => x.ItemType)
            .Description("The type of the item");

        descriptor.Field(x => x.CreatedDate)
            .Description("The creation date of the item in ISO 8601 format");
    }
}