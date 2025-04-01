using Lib.Cosmos.Adapters;
using Lib.Cosmos.Apis;
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
    [TestMethod, TestCategory("unit")]
    public void Value_PropertyShouldExist()
    {
        //arrange
        CosmosItemResponse<object> subject = new TestCosmosItemResponse<object>();

        //act
        object _ = subject.Value;

        //assert
    }

    private sealed class TestCosmosItemResponse<T> : CosmosItemResponse<T>
    {
    }
}
