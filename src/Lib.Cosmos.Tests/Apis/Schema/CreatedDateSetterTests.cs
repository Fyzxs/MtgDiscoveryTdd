using Lib.Cosmos.Apis;
using Lib.Cosmos.Apis.Schema;

namespace Lib.Cosmos.Tests.Apis.Schema;

[TestClass]
public sealed class CreatedDateSetterTests
{
    [TestMethod, TestCategory("unit")]
    public void CreatedDateSetter_ShouldExist()
    {
        //arrange

        //act
        CreatedDateSetter _ = new();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void SetCreatedDate_ShouldCreateCosmosItemWithCreatedDate()
    {
        //arrange
        CreatedDateSetter setter = new();
        string expectedCreatedDate = "2023-01-01T00:00:00.000Z";

        //act
        CosmosItem actual = setter.SetCreatedDate(expectedCreatedDate);

        //assert
        _ = actual.Should().NotBeNull();
        _ = actual.CreatedDate.Should().Be(expectedCreatedDate);
    }

    [TestMethod, TestCategory("unit")]
    public void SetCreatedDate_ShouldPreserveOtherProperties()
    {
        //arrange
        CreatedDateSetter setter = new();
        string testCreatedDate = "2023-01-01T00:00:00.000Z";

        //act
        CosmosItem actual = setter.SetCreatedDate(testCreatedDate);

        //assert
        _ = actual.Id.Should().BeNull();
        _ = actual.Partition.Should().BeNull();
        _ = actual.ItemType.Should().NotBeNull(); // ItemType has default behavior
    }
}