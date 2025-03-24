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
}
