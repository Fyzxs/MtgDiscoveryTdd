using Lib.Cosmos.Apis;
using Lib.Cosmos.Apis.Schema;

namespace Lib.Cosmos.Tests.Apis.Schema;

[TestClass]
public sealed class ItemTypeSetterTests
{
    [TestMethod, TestCategory("unit")]
    public void ItemTypeSetter_ShouldExist()
    {
        //arrange

        //act
        ItemTypeSetter _ = new();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void SetItemType_ShouldCreateCosmosItemWithItemType()
    {
        //arrange
        ItemTypeSetter setter = new();
        string expectedItemType = "test-item-type";

        //act
        CosmosItem actual = setter.SetItemType(expectedItemType);

        //assert
        _ = actual.Should().NotBeNull();
        _ = actual.ItemType.Should().Be(expectedItemType);
    }

    [TestMethod, TestCategory("unit")]
    public void SetItemType_ShouldPreserveOtherProperties()
    {
        //arrange
        ItemTypeSetter setter = new();
        string testItemType = "test-item-type";

        //act
        CosmosItem actual = setter.SetItemType(testItemType);

        //assert
        _ = actual.Id.Should().BeNull();
        _ = actual.Partition.Should().BeNull();
        _ = actual.CreatedDate.Should().NotBeNull(); // CreatedDate has default behavior
    }
}