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
        CosmosItem _ = new CosmosItem();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void Id_ShouldExist()
    {
        //arrange
        CosmosItem subject = new CosmosItem();

        //act
        string _ = subject.Id;

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void Id_ShouldSerializeProperly()
    {
        //arrange
        CosmosItem subject = new CosmosItem { Id = "SomeValue" };

        //act
        string actual = JsonConvert.SerializeObject(subject);

        //assert
        actual.Should().Contain("\"id\":\"SomeValue\"");
    }

    [TestMethod, TestCategory("unit")]
    public void Partition_ShouldExist()
    {
        //arrange

        //act
        string _ = new CosmosItem().Partition;

        //assert
    }
}
