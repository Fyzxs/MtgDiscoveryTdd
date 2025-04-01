using Lib.Cosmos.Adapters;
using TestConvenience.Universal.Tests;

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

[TestClass]
public class CosmosItemResponseTests : BaseToSystemTypeTests<CosmosItemResponse<object>, object>
{
}

public abstract class CosmosItemResponse<T>
{
}
