using System;
using HotChocolate;
using HotChocolate.Types;
using Lib.Cosmos.Apis;
using Lib.Cosmos.Apis.Schema;

namespace Lib.Cosmos.Tests.Apis.Schema;

[TestClass]
public sealed class CosmosItemTypeTests
{
    [TestMethod, TestCategory("unit")]
    public void CosmosItemType_ShouldExist()
    {
        //arrange

        //act
        CosmosItemType _ = new();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemType_ShouldInheritFromObjectType()
    {
        //arrange
        Type subject = typeof(CosmosItemType);

        //act
        bool actual = typeof(ObjectType<CosmosItem>).IsAssignableFrom(subject);

        //assert
        _ = actual.Should().BeTrue();
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemType_ShouldHaveCorrectName()
    {
        //arrange
        ISchema schema = SchemaBuilder.New()
            .AddType<CosmosItemType>()
            .AddQueryType(d => d.Name("Query").Field("dummy").Resolve("dummy"))
            .Create();

        //act
        IObjectType objectType = schema.GetType<CosmosItemType>("CosmosItem");

        //assert
        _ = objectType.Name.Should().Be("CosmosItem");
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemType_ShouldHaveDescription()
    {
        //arrange
        ISchema schema = SchemaBuilder.New()
            .AddType<CosmosItemType>()
            .AddQueryType(d => d.Name("Query").Field("dummy").Resolve("dummy"))
            .Create();

        //act
        IObjectType objectType = schema.GetType<CosmosItemType>("CosmosItem");

        //assert
        _ = objectType.Description.Should().Be("A Cosmos DB item with standard properties");
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemType_ShouldHaveIdField()
    {
        //arrange
        ISchema schema = SchemaBuilder.New()
            .AddType<CosmosItemType>()
            .AddQueryType(d => d.Name("Query").Field("dummy").Resolve("dummy"))
            .Create();
        IObjectType objectType = schema.GetType<CosmosItemType>("CosmosItem");

        //act
        IObjectField field = objectType.Fields["id"];

        //assert
        _ = field.Should().NotBeNull();
        _ = field.Description.Should().Be("The unique identifier of the item");
        _ = field.Type.IsNonNullType().Should().BeFalse();
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemType_ShouldHavePartitionField()
    {
        //arrange
        ISchema schema = SchemaBuilder.New()
            .AddType<CosmosItemType>()
            .AddQueryType(d => d.Name("Query").Field("dummy").Resolve("dummy"))
            .Create();
        IObjectType objectType = schema.GetType<CosmosItemType>("CosmosItem");

        //act
        IObjectField field = objectType.Fields["partition"];

        //assert
        _ = field.Should().NotBeNull();
        _ = field.Description.Should().Be("The partition key of the item");
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemType_ShouldHaveItemTypeField()
    {
        //arrange
        ISchema schema = SchemaBuilder.New()
            .AddType<CosmosItemType>()
            .AddQueryType(d => d.Name("Query").Field("dummy").Resolve("dummy"))
            .Create();
        IObjectType objectType = schema.GetType<CosmosItemType>("CosmosItem");

        //act
        IObjectField field = objectType.Fields["itemType"];

        //assert
        _ = field.Should().NotBeNull();
        _ = field.Description.Should().Be("The type of the item");
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemType_ShouldHaveCreatedDateField()
    {
        //arrange
        ISchema schema = SchemaBuilder.New()
            .AddType<CosmosItemType>()
            .AddQueryType(d => d.Name("Query").Field("dummy").Resolve("dummy"))
            .Create();
        IObjectType objectType = schema.GetType<CosmosItemType>("CosmosItem");

        //act
        IObjectField field = objectType.Fields["createdDate"];

        //assert
        _ = field.Should().NotBeNull();
        _ = field.Description.Should().Be("The creation date of the item in ISO 8601 format");
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemType_ShouldResolveCorrectly()
    {
        //arrange
        CosmosItem testItem = new()
        {
            Id = "test-id",
            Partition = "test-partition",
            ItemType = "test-type",
            CreatedDate = "2023-01-01T00:00:00.000Z"
        };

        ISchema schema = SchemaBuilder.New()
            .AddType<CosmosItemType>()
            .AddQueryType(d => d.Name("Query").Field("testItem").Resolve(testItem))
            .Create();

        //act
        string result = schema.ToString();

        //assert
        _ = result.Should().Contain("type CosmosItem");
        _ = result.Should().Contain("id: String");
        _ = result.Should().Contain("partition: String");
        _ = result.Should().Contain("itemType: String");
        _ = result.Should().Contain("createdDate: String");
    }
}