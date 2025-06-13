using System;
using HotChocolate;
using HotChocolate.Types;
using Lib.Cosmos.Apis;
using Lib.Cosmos.Apis.Schema;

namespace Lib.Cosmos.Tests.Apis.Schema;

[TestClass]
public sealed class CosmosItemQueryTests
{
    [TestMethod, TestCategory("unit")]
    public void CosmosItemQuery_ShouldExist()
    {
        //arrange

        //act
        CosmosItemQuery _ = new();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemQuery_ShouldInheritFromObjectType()
    {
        //arrange
        Type subject = typeof(CosmosItemQuery);

        //act
        bool actual = typeof(ObjectType).IsAssignableFrom(subject);

        //assert
        _ = actual.Should().BeTrue();
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemQuery_ShouldHaveCorrectName()
    {
        //arrange
        ISchema schema = SchemaBuilder.New()
            .AddType<CosmosItemType>()
            .AddQueryType<CosmosItemQuery>()
            .Create();

        //act
        IObjectType queryType = schema.QueryType;

        //assert
        _ = queryType.Name.Should().Be("Query");
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemQuery_ShouldHaveDescription()
    {
        //arrange
        ISchema schema = SchemaBuilder.New()
            .AddType<CosmosItemType>()
            .AddQueryType<CosmosItemQuery>()
            .Create();

        //act
        IObjectType queryType = schema.QueryType;

        //assert
        _ = queryType.Description.Should().Be("Root query for CosmosItem operations");
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemQuery_ShouldHaveSetIdField()
    {
        //arrange
        ISchema schema = SchemaBuilder.New()
            .AddType<CosmosItemType>()
            .AddQueryType<CosmosItemQuery>()
            .Create();
        IObjectType queryType = schema.QueryType;

        //act
        IObjectField field = queryType.Fields["setId"];

        //assert
        _ = field.Should().NotBeNull();
        _ = field.Description.Should().Be("Create a CosmosItem with the specified ID");
        _ = field.Arguments.Should().HaveCount(1);
        _ = field.Arguments["id"].Should().NotBeNull();
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemQuery_ShouldHaveSetPartitionField()
    {
        //arrange
        ISchema schema = SchemaBuilder.New()
            .AddType<CosmosItemType>()
            .AddQueryType<CosmosItemQuery>()
            .Create();
        IObjectType queryType = schema.QueryType;

        //act
        IObjectField field = queryType.Fields["setPartition"];

        //assert
        _ = field.Should().NotBeNull();
        _ = field.Description.Should().Be("Create a CosmosItem with the specified partition");
        _ = field.Arguments.Should().HaveCount(1);
        _ = field.Arguments["partition"].Should().NotBeNull();
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemQuery_ShouldHaveSetItemTypeField()
    {
        //arrange
        ISchema schema = SchemaBuilder.New()
            .AddType<CosmosItemType>()
            .AddQueryType<CosmosItemQuery>()
            .Create();
        IObjectType queryType = schema.QueryType;

        //act
        IObjectField field = queryType.Fields["setItemType"];

        //assert
        _ = field.Should().NotBeNull();
        _ = field.Description.Should().Be("Create a CosmosItem with the specified item type");
        _ = field.Arguments.Should().HaveCount(1);
        _ = field.Arguments["itemType"].Should().NotBeNull();
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemQuery_ShouldHaveSetCreatedDateField()
    {
        //arrange
        ISchema schema = SchemaBuilder.New()
            .AddType<CosmosItemType>()
            .AddQueryType<CosmosItemQuery>()
            .Create();
        IObjectType queryType = schema.QueryType;

        //act
        IObjectField field = queryType.Fields["setCreatedDate"];

        //assert
        _ = field.Should().NotBeNull();
        _ = field.Description.Should().Be("Create a CosmosItem with the specified created date");
        _ = field.Arguments.Should().HaveCount(1);
        _ = field.Arguments["createdDate"].Should().NotBeNull();
    }
}