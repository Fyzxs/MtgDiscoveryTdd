using Lib.Cosmos.Apis;
using Lib.Cosmos.Apis.Schema;

namespace Lib.Cosmos.Tests.Apis.Schema;

[TestClass]
public sealed class PartitionSetterTests
{
    [TestMethod, TestCategory("unit")]
    public void PartitionSetter_ShouldExist()
    {
        //arrange

        //act
        PartitionSetter _ = new();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void SetPartition_ShouldCreateCosmosItemWithPartition()
    {
        //arrange
        PartitionSetter setter = new();
        string expectedPartition = "test-partition";

        //act
        CosmosItem actual = setter.SetPartition(expectedPartition);

        //assert
        _ = actual.Should().NotBeNull();
        _ = actual.Partition.Should().Be(expectedPartition);
    }

    [TestMethod, TestCategory("unit")]
    public void SetPartition_ShouldPreserveOtherProperties()
    {
        //arrange
        PartitionSetter setter = new();
        string testPartition = "test-partition";

        //act
        CosmosItem actual = setter.SetPartition(testPartition);

        //assert
        _ = actual.Id.Should().BeNull();
        _ = actual.ItemType.Should().NotBeNull(); // ItemType has default behavior
        _ = actual.CreatedDate.Should().NotBeNull(); // CreatedDate has default behavior
    }
}