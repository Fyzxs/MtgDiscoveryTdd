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
}
