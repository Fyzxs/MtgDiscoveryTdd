using System;
using System.Reflection;
using Newtonsoft.Json;

namespace Lib.Cosmos.Tests;

[TestClass]
public class CosmosItemTests
{
    [TestMethod, TestCategory("unit")]
    public void CosmosItem_ShouldExist()
    {
        //arrange

        //act
        CosmosItem _ = new();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void Id_ShouldExist()
    {
        //arrange
        CosmosItem subject = new();

        //act
        string _ = subject.Id;

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void Id_ShouldSerializeLowerSnakeCase()
    {
        //arrange
        CosmosItem subject = new() { Id = "SomeValue" };

        //act
        string actual = JsonConvert.SerializeObject(subject);

        //assert
        _ = actual.Should().Contain("\"id\":\"SomeValue\"");
    }

    [TestMethod, TestCategory("unit")]
    public void Partition_ShouldExist()
    {
        //arrange

        //act
        string _ = new CosmosItem().Partition;

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void Partition_ShouldSerializeLowerSnakeCase()
    {
        //arrange
        CosmosItem subject = new() { Partition = "myValue" };

        //act
        string actual = JsonConvert.SerializeObject(subject);

        //assert
        _ = actual.Should().Contain("\"partition\":\"myValue\"");
    }

    [TestMethod, TestCategory("unit")]
    public void ItemType_ShouldExist()
    {
        //arrange

        //act
        string _ = new CosmosItem().ItemType;

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void ItemType_ShouldSerializeLowerSnakeCase()
    {
        //arrange
        CosmosItem subject = new() { ItemType = "myType" };

        //act
        string actual = JsonConvert.SerializeObject(subject);

        //assert
        _ = actual.Should().Contain("\"item_type\":\"myType\"");
    }

    [TestMethod, TestCategory("unit")]
    public void ItemType_ShouldReturnFqdn()
    {
        //arrange
        CosmosItem subject = new();

        //act
        string actual = subject.ItemType;

        //assert
        _ = actual.Should().Be("Lib.Cosmos.CosmosItem");
    }

    [TestMethod, TestCategory("unit")]
    public void CreatedDate_ShouldExist()
    {
        //arrange

        //act
        string _ = new CosmosItem().CreatedDate;

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void CreatedDate_ShouldSerializeLowerSnakeCase()
    {
        //arrange
        CosmosItem subject = new() { CreatedDate = "myDate" };

        //act
        string actual = JsonConvert.SerializeObject(subject);

        //assert
        _ = actual.Should().Contain("\"created_date\":\"myDate\"");
    }

    [TestMethod, TestCategory("unit")]
    public void CreatedDate_ShouldReturnUtcNowIso8601()
    {
        //arrange
        CosmosItem subject = new();

        //act
        string actual = subject.CreatedDate;

        //assert
        DateTime universalTime = DateTime.Parse(actual).ToUniversalTime();
        _ = universalTime.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [TestMethod, TestCategory("unit")]
    public void Id_ShouldBeOverridable()
    {
        //arrange
        PropertyInfo propertyInfo = typeof(CosmosItem).GetProperty("Id");

        //act
        bool actual = propertyInfo?.GetMethod is { IsVirtual: true, IsFinal: false };

        //assert
        _ = actual.Should().BeTrue();
    }
}
