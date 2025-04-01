namespace Lib.Cosmos.Tests.Adapters;

[TestClass]
public class CosmosContainerUpsertAdapterTests
{
    [TestMethod, TestCategory("unit")]
    public void Should_Exist()
    {
        //arrange

        //act
        ICosmosContainerUpsertAdapter _ = new CosmosContainerUpsertAdapter();

        //assert

    }
}

public class CosmosContainerUpsertAdapter : ICosmosContainerUpsertAdapter
{
    public void Foo() => throw new System.NotImplementedException();
}

public interface ICosmosContainerUpsertAdapter
{
    void Foo();
}
