using Lib.Cosmos.Apis;
using Lib.Cosmos.Apis.Schema;

namespace Lib.Cosmos.Tests.Apis.Schema;

[TestClass]
public sealed class IdSetterTests
{
    [TestMethod, TestCategory("unit")]
    public void IdSetter_ShouldExist()
    {
        //arrange

        //act
        IdSetter _ = new();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void SetId_ShouldCreateCosmosItemWithId()
    {
        //arrange
        IdSetter setter = new();
        string expectedId = "test-id";

        //act
        CosmosItem actual = setter.SetId(expectedId);

        //assert
        _ = actual.Should().NotBeNull();
        _ = actual.Id.Should().Be(expectedId);
    }

    [TestMethod, TestCategory("unit")]
    public void SetId_ShouldPreserveOtherProperties()
    {
        //arrange
        IdSetter setter = new();
        string testId = "test-id";

        //act
        CosmosItem actual = setter.SetId(testId);

        //assert
        _ = actual.Partition.Should().BeNull();
        _ = actual.ItemType.Should().NotBeNull(); // ItemType has default behavior
        _ = actual.CreatedDate.Should().NotBeNull(); // CreatedDate has default behavior
    }
}