using HotChocolate.Types;

namespace Lib.Cosmos.Apis.Schema;

public sealed class CosmosItemQuery : ObjectType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.Name("Query");
        descriptor.Description("Root query for CosmosItem operations");

        descriptor.Field("setId")
            .Description("Create a CosmosItem with the specified ID")
            .Argument("id", a => a.Type<StringType>().Description("The ID to set"))
            .Type<CosmosItemType>()
            .Resolve(context =>
            {
                string id = context.ArgumentValue<string>("id");
                IdSetter setter = new();
                return setter.SetId(id);
            });

        descriptor.Field("setPartition")
            .Description("Create a CosmosItem with the specified partition")
            .Argument("partition", a => a.Type<StringType>().Description("The partition to set"))
            .Type<CosmosItemType>()
            .Resolve(context =>
            {
                string partition = context.ArgumentValue<string>("partition");
                PartitionSetter setter = new();
                return setter.SetPartition(partition);
            });

        descriptor.Field("setItemType")
            .Description("Create a CosmosItem with the specified item type")
            .Argument("itemType", a => a.Type<StringType>().Description("The item type to set"))
            .Type<CosmosItemType>()
            .Resolve(context =>
            {
                string itemType = context.ArgumentValue<string>("itemType");
                ItemTypeSetter setter = new();
                return setter.SetItemType(itemType);
            });

        descriptor.Field("setCreatedDate")
            .Description("Create a CosmosItem with the specified created date")
            .Argument("createdDate", a => a.Type<StringType>().Description("The created date to set"))
            .Type<CosmosItemType>()
            .Resolve(context =>
            {
                string createdDate = context.ArgumentValue<string>("createdDate");
                CreatedDateSetter setter = new();
                return setter.SetCreatedDate(createdDate);
            });
    }
}